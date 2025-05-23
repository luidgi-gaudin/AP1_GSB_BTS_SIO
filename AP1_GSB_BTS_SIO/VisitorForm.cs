﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;
using AP1_GSB_BTS_SIO.Models;
using AP1_GSB_BTS_SIO.Services;
using System.Collections.Generic;

namespace AP1_GSB_BTS_SIO
{
    public partial class VisitorForm : Form
    {
        private string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";
        private int visitorId;
        public string AnneeMois;
        private readonly int _visitorId;
        private readonly FicheDeFraisService _ficheService;
        private readonly DetailFraisService _detailService;
        private FicheDeFrais _currentFiche;
        private List<DetailFrais> _forfaitFrais;
        private List<DetailFrais> _horsForfaitFrais;


        // intitalisation des differentes données pour le visiteur
        public VisitorForm(int visitorId)
        {
            CurrentYearMonth();
            this.visitorId = visitorId;
            CreateMonthlyExpenseReport();
            InitializeComponent();
        }

        private void VisitorForm_Load(object sender, EventArgs e)
        {
            LoadCurrentExpenseReport();
        }

        //verifie si la fiche de frais existe et la crée si elle n'existe pas
        #region Verifie si la fiche de frais existe et la crée si elle n'existe pas
        private void CreateMonthlyExpenseReport()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlTransaction transaction = null;

                try
                {
                    conn.Open();

                    // Insérer la nouvelle ligne si elle n'existe pas déjà
                    string insertQuery = @"
                INSERT INTO fichedefrais (id_utilisateur, AnneeMois, Montant, id_etat)
                SELECT @id_utilisateur, @AnneeMois, 0, 2
                FROM DUAL
                WHERE NOT EXISTS (
                    SELECT 1
                    FROM fichedefrais
                    WHERE id_utilisateur = @id_utilisateur
                    AND AnneeMois = @AnneeMois
                )";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn, transaction);
                    insertCmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    insertCmd.Parameters.AddWithValue("@AnneeMois", AnneeMois);
                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Calculer le mois précédent
                        DateTime currentMonth = DateTime.ParseExact(AnneeMois, "yyyy-MM", null);
                        string previousMonth = currentMonth.AddMonths(-1).ToString("yyyy-MM");

                        // Mettre à jour l'état du mois précédent
                        string updateQuery = @"
                    UPDATE fichedefrais
                    SET id_etat = 1
                    WHERE id_utilisateur = @id_utilisateur
                    AND AnneeMois = @PreviousAnneeMois";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn, transaction);
                        updateCmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                        updateCmd.Parameters.AddWithValue("@PreviousAnneeMois", previousMonth);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Fiche de frais créée avec succès.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        #endregion

        //charger la fiche de frais actuelle
        #region Charger la fiche de frais actuelle
        private void LoadCurrentExpenseReport()
        {
            listViewForfait.Items.Clear();
            listViewHorsForfait.Items.Clear();

            // Charge les frais forfaitaires
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
        SELECT f.id_fichedeFrais, f.AnneeMois, ff.id_fraisForfait, ff.Montant_total, tf.TypeFrai, ff.quantite, DATE_FORMAT(ff.date_frais, '%Y-%m-%d') AS date_frais
        FROM fichedefrais f
        LEFT JOIN fraisforfait ff ON f.id_fichedeFrais = ff.id_fichedeFrais
        LEFT JOIN typefrais tf ON ff.id_typeFrais = tf.id_typeFrais
        WHERE f.id_utilisateur = @id_utilisateur
        AND f.AnneeMois = @AnneeMois";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    cmd.Parameters.AddWithValue("@AnneeMois", AnneeMois);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    bool hasRows = false;
                    while (reader.Read())
                    {
                        hasRows = true;
                        ListViewItem item = new ListViewItem(reader["TypeFrai"].ToString());
                        item.SubItems.Add(reader["quantite"].ToString());
                        item.SubItems.Add(reader["Montant_total"].ToString());

                        string dateString = reader["date_frais"].ToString();
                        if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dateFrais))
                        {
                            item.SubItems.Add(dateFrais.ToString("dd/MM/yyyy"));
                        }
                        else
                        {
                            item.SubItems.Add("Date invalide");
                        }

                        listViewForfait.Items.Add(item);
                    }
                    reader.Close();
                    if (!hasRows)
                    {
                        MessageBox.Show("Aucun frais forfaitaire trouvé pour cet utilisateur.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des frais forfaitaires : " + ex.Message);
                }
            }

            // Charge les frais hors forfait
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
        SELECT f.id_fichedeFrais, f.AnneeMois, hf.id_fraisHorsForfait, hf.description, hf.montant, DATE_FORMAT(hf.date_fraishors, '%Y-%m-%d') AS date_fraishors
        FROM fichedefrais f
        LEFT JOIN fraishorsforfait hf ON f.id_fichedeFrais = hf.id_fichedeFrais
        WHERE f.id_utilisateur = @id_utilisateur
        AND f.AnneeMois = @AnneeMois";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    cmd.Parameters.AddWithValue("@AnneeMois", AnneeMois);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    bool hasRows = false;
                    while (reader.Read())
                    {
                        hasRows = true;
                        ListViewItem item = new ListViewItem(reader["description"].ToString());
                        item.SubItems.Add(reader["montant"].ToString());

                        string dateString = reader["date_fraishors"].ToString();
                        if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dateFraisHors))
                        {
                            item.SubItems.Add(dateFraisHors.ToString("dd/MM/yyyy"));
                        }
                        else
                        {
                            item.SubItems.Add("Date invalide");
                        }

                        listViewHorsForfait.Items.Add(item);
                    }
                    reader.Close();
                    if (!hasRows)
                    {
                        MessageBox.Show("Aucun frais hors forfait trouvé pour cet utilisateur.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des frais hors forfait : " + ex.Message);
                }
            }
        }
        #endregion



        //commandes SQL ajout modif
        #region commande SQL ajout modif
        // Execute la commande SQL pour ajouter un frais forfaitaire
        private void btnAddForfait_Click(object sender, EventArgs e)
        {
            ForfaitDialog forfaitDialog = new ForfaitDialog();
            if (forfaitDialog.ShowDialog() == DialogResult.OK)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = @"
                            INSERT INTO fraisforfait (id_fichedeFrais, id_typeFrais, quantite,Montant_total, date_frais)
                            VALUES (
                                (SELECT id_fichedeFrais FROM fichedefrais WHERE id_utilisateur = @id_utilisateur AND AnneeMois = @AnneeMois),
                                @id_typeFrais, @quantite,@Montant_total, @date_frais)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                        cmd.Parameters.AddWithValue("@id_typeFrais", forfaitDialog.IdTypeFrais);
                        cmd.Parameters.AddWithValue("@Montant_total", forfaitDialog.MontantTotal);
                        cmd.Parameters.AddWithValue("@quantite", forfaitDialog.Quantite);
                        cmd.Parameters.AddWithValue("@date_frais", forfaitDialog.Date_frais);
                        cmd.Parameters.AddWithValue("@AnneeMois", AnneeMois);
                        cmd.ExecuteNonQuery();
                        LoadCurrentExpenseReport();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        // Execute la commande SQL pour ajouter un frais hors forfait
        private void btnAddHorsForfait_Click(object sender, EventArgs e)
        {
            HorsForfaitDialog horsForfaitDialog = new HorsForfaitDialog();
            if (horsForfaitDialog.ShowDialog() == DialogResult.OK)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = @"
                            INSERT INTO fraishorsforfait (id_fichedeFrais, description, montant, date_fraishors)
                            VALUES (
                                (SELECT id_fichedeFrais FROM fichedefrais WHERE id_utilisateur = @id_utilisateur AND AnneeMois = @AnneeMois),
                                @description, @montant, @date)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                        cmd.Parameters.AddWithValue("@description", horsForfaitDialog.Description);
                        cmd.Parameters.AddWithValue("@montant", horsForfaitDialog.Montant);
                        cmd.Parameters.AddWithValue("@date", horsForfaitDialog.Date_frais);
                        cmd.Parameters.AddWithValue("@AnneeMois", AnneeMois);
                        cmd.ExecuteNonQuery();
                        LoadCurrentExpenseReport();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        // Execute la commande SQL pour ajouter un justificatif
        private void btnAddJustificatif_Click(object sender, EventArgs e)
        {
            JustificatifDialog justificatifDialog = new JustificatifDialog();
            if (justificatifDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = justificatifDialog.FilePath;
                string fileName = Path.GetFileName(filePath);
                byte[] fileData = File.ReadAllBytes(filePath);

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = @"
                            INSERT INTO justificatif (id_ficheFrais, nom_fichier, fichier)
                            VALUES (
                                (SELECT id_fichedeFrais FROM fichedefrais WHERE id_utilisateur = @id_utilisateur AND AnneeMois = @AnneeMois),
                                @nom_fichier, @fichier)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                        cmd.Parameters.AddWithValue("@nom_fichier", fileName);
                        cmd.Parameters.AddWithValue("@fichier", fileData);
                        cmd.Parameters.AddWithValue("@AnneeMois", AnneeMois);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Justificatif ajouté avec succès.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        #endregion

        // Execute la commande SQL pour ouvrir la fenetre d'historique
        private void BtnViewHistory_Click(object sender, EventArgs e)
        {
            using (HistoryForm historyForm = new HistoryForm(visitorId))
            {
                historyForm.ShowDialog();
            }
        }


        // fait le pdf
        #region PDF
        // Exporte la fiche de frais au format PDF
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    ExportToPDF(fileName);
                }
            }
        }

        private void ExportToPDF(string fileName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Retrieve user and fiche info
                    string userInfoQuery = @"
                        SELECT u.nom, u.prenom, f.AnneeMois, e.etat
                        FROM fichedefrais f
                        JOIN utilisateur u ON f.id_utilisateur = u.id_utilisateur
                        JOIN etat e ON f.id_etat = e.id_etat
                        WHERE f.id_utilisateur = @id_utilisateur
                        AND f.AnneeMois = @AnneeMois";
                    MySqlCommand userInfoCmd = new MySqlCommand(userInfoQuery, conn);
                    userInfoCmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    userInfoCmd.Parameters.AddWithValue("@AnneeMois", AnneeMois);
                    MySqlDataReader userInfoReader = userInfoCmd.ExecuteReader();
                    string nom = "", prenom = "", anneeMois = "", etat = "", dateCreation = "";
                    if (userInfoReader.Read())
                    {
                        nom = userInfoReader["nom"].ToString();
                        prenom = userInfoReader["prenom"].ToString();
                        anneeMois = userInfoReader["AnneeMois"].ToString();
                        etat = userInfoReader["etat"].ToString();
                        dateCreation = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    userInfoReader.Close();

                    Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                    PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                    document.Open();


                    // Titre
                    Paragraph title = new Paragraph($"FICHE DE FRAIS DE {anneeMois.ToUpper()}", FontFactory.GetFont(FontFactory.HELVETICA, 16, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);

                    Paragraph createdOn = new Paragraph($"Créée le : {DateTime.Now.ToString("dd/MM/yyyy")}", FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.ITALIC));
                    createdOn.Alignment = Element.ALIGN_RIGHT;
                    document.Add(createdOn);

                    document.Add(new Paragraph(" ")); 
                    // Information utilisateur
                    PdfPTable userInfoTable = new PdfPTable(2);
                    userInfoTable.WidthPercentage = 100;
                    PdfPCell cell = new PdfPCell(new Phrase("VOS INFORMATIONS", FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD, new BaseColor(255, 255, 255))));
                    cell.Colspan = 2;
                    cell.BackgroundColor = new BaseColor(79, 129, 189);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 5;
                    userInfoTable.AddCell(cell);
                    userInfoTable.AddCell(CreateCell($"Nom : {nom}", PdfPCell.ALIGN_LEFT));
                    userInfoTable.AddCell(CreateCell($"Prénom : {prenom}", PdfPCell.ALIGN_LEFT));
                    userInfoTable.AddCell(CreateCell($"État fiche : {etat}", PdfPCell.ALIGN_LEFT));
                    userInfoTable.AddCell(CreateCell($" ", PdfPCell.ALIGN_LEFT));
                    document.Add(userInfoTable);

                    document.Add(new Paragraph(" ")); 
                    document.Add(new Paragraph(" ")); 
                    document.Add(new Paragraph(" ")); 

                    // Tableau des frais forfait
                    Paragraph forfaitTitle = new Paragraph("VOS FRAIS FORFAITS", FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                    forfaitTitle.Alignment = Element.ALIGN_CENTER;
                    document.Add(forfaitTitle);

                    document.Add(new Paragraph(" ")); 
                    document.Add(new Paragraph(" ")); 

                    PdfPTable forfaitTable = new PdfPTable(4);
                    forfaitTable.WidthPercentage = 100;
                    forfaitTable.AddCell(CreateCell("Date du frais", PdfPCell.ALIGN_CENTER, true));
                    forfaitTable.AddCell(CreateCell("Nom du frais", PdfPCell.ALIGN_CENTER, true));
                    forfaitTable.AddCell(CreateCell("Quantité", PdfPCell.ALIGN_CENTER, true));
                    forfaitTable.AddCell(CreateCell("Montant du frais", PdfPCell.ALIGN_CENTER, true));

                    double totalForfait = 0;

                    string fraisForfaitQuery = @"
                        SELECT tf.TypeFrai, ff.Montant_total, ff.quantite, DATE_FORMAT(ff.date_frais, '%d/%m/%Y') AS date_frais
                        FROM fraisforfait ff
                        JOIN fichedefrais f ON ff.id_fichedeFrais = f.id_fichedeFrais
                        JOIN typefrais tf ON ff.id_typeFrais = tf.id_typeFrais
                        WHERE f.id_utilisateur = @id_utilisateur
                        AND f.AnneeMois = @AnneeMois";
                    MySqlCommand forfaitCmd = new MySqlCommand(fraisForfaitQuery, conn);
                    forfaitCmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    forfaitCmd.Parameters.AddWithValue("@AnneeMois", AnneeMois);
                    MySqlDataReader forfaitReader = forfaitCmd.ExecuteReader();

                    while (forfaitReader.Read())
                    {
                        if (!forfaitReader.IsDBNull(forfaitReader.GetOrdinal("TypeFrai")))
                        {
                            forfaitTable.AddCell(CreateCell(forfaitReader["date_frais"].ToString(), PdfPCell.ALIGN_CENTER));
                            forfaitTable.AddCell(CreateCell(forfaitReader["TypeFrai"].ToString(), PdfPCell.ALIGN_CENTER));
                            string quantite = forfaitReader["quantite"].ToString();
                            forfaitTable.AddCell(CreateCell(quantite, PdfPCell.ALIGN_CENTER));
                            string montantTotal = forfaitReader["Montant_total"].ToString();
                            forfaitTable.AddCell(CreateCell(montantTotal + " €", PdfPCell.ALIGN_CENTER));
                            totalForfait += Convert.ToDouble(montantTotal);
                        }
                    }
                    forfaitReader.Close();
                    document.Add(forfaitTable);

                    document.Add(new Paragraph(" ")); 
                    document.Add(new Paragraph(" "));
                    // Tableau des frais hors forfait
                    Paragraph horsForfaitTitle = new Paragraph("VOS FRAIS HORS FORFAITS", FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                    horsForfaitTitle.Alignment = Element.ALIGN_CENTER;
                    document.Add(horsForfaitTitle);

                    document.Add(new Paragraph(" ")); 
                    document.Add(new Paragraph(" ")); 

                    PdfPTable horsForfaitTable = new PdfPTable(3);
                    horsForfaitTable.WidthPercentage = 100;
                    horsForfaitTable.AddCell(CreateCell("Date du frais", PdfPCell.ALIGN_CENTER, true));
                    horsForfaitTable.AddCell(CreateCell("Nom du frais", PdfPCell.ALIGN_CENTER, true));
                    horsForfaitTable.AddCell(CreateCell("Montant du frais", PdfPCell.ALIGN_CENTER, true));

                    double totalHorsForfait = 0;

                    string fraisHorsForfaitQuery = @"
                        SELECT description, ff.montant, DATE_FORMAT(date_fraishors, '%d/%m/%Y') AS date_fraishors
                        FROM fraishorsforfait ff
                        JOIN fichedefrais f ON ff.id_fichedeFrais = f.id_fichedeFrais
                        WHERE f.id_utilisateur = @id_utilisateur
                        AND f.AnneeMois = @AnneeMois";
                    MySqlCommand horsForfaitCmd = new MySqlCommand(fraisHorsForfaitQuery, conn);
                    horsForfaitCmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    horsForfaitCmd.Parameters.AddWithValue("@AnneeMois", AnneeMois);
                    MySqlDataReader horsForfaitReader = horsForfaitCmd.ExecuteReader();

                    while (horsForfaitReader.Read())
                    {
                        if (!horsForfaitReader.IsDBNull(horsForfaitReader.GetOrdinal("description")))
                        {
                            horsForfaitTable.AddCell(CreateCell(horsForfaitReader["date_fraishors"].ToString(), PdfPCell.ALIGN_CENTER));
                            horsForfaitTable.AddCell(CreateCell(horsForfaitReader["description"].ToString(), PdfPCell.ALIGN_CENTER));
                            string montant = horsForfaitReader["montant"].ToString();
                            horsForfaitTable.AddCell(CreateCell(montant + " €", PdfPCell.ALIGN_CENTER));
                            totalHorsForfait += Convert.ToDouble(montant);
                        }
                    }
                    horsForfaitReader.Close();
                    document.Add(horsForfaitTable);

                    document.Add(new Paragraph(" ")); 

                    document.Add(new Paragraph(" ")); 

                    document.Add(new Paragraph(" ")); 

                    // Recapitulatif
                    Paragraph recapTitle = new Paragraph("RECAPITULATIF", FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                    recapTitle.Alignment = Element.ALIGN_LEFT;
                    document.Add(recapTitle);

                    document.Add(new Paragraph(" ")); 
                    document.Add(new Paragraph(" ")); 

                    PdfPTable recapTable = new PdfPTable(2);
                    recapTable.WidthPercentage = 50;
                    recapTable.AddCell(CreateCell("Total de vos frais forfaits :", PdfPCell.ALIGN_LEFT, true));
                    recapTable.AddCell(CreateCell($"{totalForfait.ToString("F2")} €", PdfPCell.ALIGN_RIGHT));
                    recapTable.AddCell(CreateCell("Total de vos frais hors forfaits :", PdfPCell.ALIGN_LEFT, true));
                    recapTable.AddCell(CreateCell($"{totalHorsForfait.ToString("F2")} €", PdfPCell.ALIGN_RIGHT));
                    recapTable.AddCell(CreateCell("Total de votre fiche de frais :", PdfPCell.ALIGN_LEFT, true));
                    recapTable.AddCell(CreateCell($"{(totalForfait + totalHorsForfait).ToString("F2")} €", PdfPCell.ALIGN_RIGHT));
                    recapTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    document.Add(recapTable);

                    document.Close();
                    MessageBox.Show("Fiche de frais exportée avec succès.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private PdfPCell CreateCell(string text, int alignment, bool isBold = false)
        {
            iTextSharp.text.Font font = isBold ? FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.BOLD) : FontFactory.GetFont(FontFactory.HELVETICA, 10);
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = alignment;
            cell.Border = PdfPCell.NO_BORDER;
            return cell;
        }
        #endregion

        private void listViewForfait_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Ramene au login
        private void btnLogoutV_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
            this.Close();
        }

        //calcule l'annee mois actuel
        private void CurrentYearMonth()
        {
            DateTime date = DateTime.Now;
            if(date.Day<=10)
            {
                date = date.AddMonths(-1);
                AnneeMois = date.ToString("yyyy-MM");
            }
            else
            {
                AnneeMois = date.ToString("yyyy-MM");
            }

            
        }
    }
}
