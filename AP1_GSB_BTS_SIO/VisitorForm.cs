using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AP1_GSB_BTS_SIO
{
    public partial class VisitorForm : Form
    {
        private string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";
        private int visitorId;

        public VisitorForm(int visitorId)
        {
            InitializeComponent();
            this.visitorId = visitorId;
            CreateMonthlyExpenseReport();
        }

        private void VisitorForm_Load(object sender, EventArgs e)
        {
            LoadCurrentExpenseReport();
        }

        private void CreateMonthlyExpenseReport()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO fichedefrais (id_utilisateur, AnneeMois, Montant, Etat, id_etat)
                        SELECT @id_utilisateur, DATE_FORMAT(NOW(), '%Y-%m'), 0, 'EN COURS', 1
                        FROM DUAL
                        WHERE NOT EXISTS (
                            SELECT 1
                            FROM fichedefrais
                            WHERE id_utilisateur = @id_utilisateur
                            AND AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')
                        )";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

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
                SELECT f.id_fichedeFrais, f.AnneeMois, f.Etat, ff.id_fraisForfait, ff.Montant_total, tf.TypeFrai
                FROM fichedefrais f
                LEFT JOIN fraisforfait ff ON f.id_fichedeFrais = ff.id_fichedeFrais
                LEFT JOIN typefrais tf ON ff.id_typeFrais = tf.id_typeFrais
                WHERE f.id_utilisateur = @id_utilisateur
                AND f.AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    bool hasRows = false;
                    while (reader.Read())
                    {
                        hasRows = true;
                        ListViewItem item = new ListViewItem(reader["TypeFrai"].ToString());
                        item.SubItems.Add(reader["Etat"].ToString());
                        item.SubItems.Add(reader["Montant_total"].ToString());
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
                SELECT f.id_fichedeFrais, f.AnneeMois, f.Etat, hf.id_fraisHorsForfait, hf.description, hf.montant
                FROM fichedefrais f
                LEFT JOIN fraishorsforfait hf ON f.id_fichedeFrais = hf.id_fichedeFrais
                WHERE f.id_utilisateur = @id_utilisateur
                AND f.AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    bool hasRows = false;
                    while (reader.Read())
                    {
                        hasRows = true;
                        ListViewItem item = new ListViewItem(reader["description"].ToString());
                        item.SubItems.Add(reader["Etat"].ToString());
                        item.SubItems.Add(reader["montant"].ToString());
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
                            INSERT INTO fraisforfait (id_fichedeFrais, id_typeFrais, Montant_total)
                            VALUES (
                                (SELECT id_fichedeFrais FROM fichedefrais WHERE id_utilisateur = @id_utilisateur AND AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')),
                                @id_typeFrais, @Montant_total)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                        cmd.Parameters.AddWithValue("@id_typeFrais", forfaitDialog.IdTypeFrais);
                        cmd.Parameters.AddWithValue("@Montant_total", forfaitDialog.MontantTotal);
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
                            INSERT INTO fraishorsforfait (id_fichedeFrais, description, montant)
                            VALUES (
                                (SELECT id_fichedeFrais FROM fichedefrais WHERE id_utilisateur = @id_utilisateur AND AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')),
                                @description, @montant)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                        cmd.Parameters.AddWithValue("@description", horsForfaitDialog.Description);
                        cmd.Parameters.AddWithValue("@montant", horsForfaitDialog.Montant);
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
                                (SELECT id_fichedeFrais FROM fichedefrais WHERE id_utilisateur = @id_utilisateur AND AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')),
                                @nom_fichier, @fichier)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                        cmd.Parameters.AddWithValue("@nom_fichier", fileName);
                        cmd.Parameters.AddWithValue("@fichier", fileData);
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

        private void btnViewCurrent_Click(object sender, EventArgs e)
        {
            LoadCurrentExpenseReport();
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            listViewForfait.Items.Clear();
            listViewHorsForfait.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT f.AnneeMois, f.Etat, hf.description, hf.montant
                        FROM fichedefrais f
                        LEFT JOIN fraishorsforfait hf ON f.id_fichedeFrais = hf.id_fichedeFrais
                        WHERE f.id_utilisateur = @id_utilisateur
                        ORDER BY f.AnneeMois DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["description"].ToString());
                        item.SubItems.Add(reader["Etat"].ToString());
                        item.SubItems.Add(reader["montant"].ToString());
                        item.SubItems.Add(reader["AnneeMois"].ToString());
                        listViewHorsForfait.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

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
                    // Retrieve user information
                    string userInfoQuery = @"
        SELECT u.nom, u.prenom, f.AnneeMois, f.Etat
        FROM fichedefrais f
        JOIN utilisateur u ON f.id_utilisateur = u.id_utilisateur
        WHERE f.id_utilisateur = @id_utilisateur
        AND f.AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')";
                    MySqlCommand userInfoCmd = new MySqlCommand(userInfoQuery, conn);
                    userInfoCmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    MySqlDataReader userInfoReader = userInfoCmd.ExecuteReader();
                    string nom = "", prenom = "", anneeMois = "", etat = "";
                    if (userInfoReader.Read())
                    {
                        nom = userInfoReader["nom"].ToString();
                        prenom = userInfoReader["prenom"].ToString();
                        anneeMois = userInfoReader["AnneeMois"].ToString();
                        etat = userInfoReader["Etat"].ToString();
                    }
                    userInfoReader.Close();

                    // Retrieve frais forfait
                    string fraisForfaitQuery = @"
        SELECT tf.TypeFrai, ff.Montant_total, f.Etat
        FROM fichedefrais f
        LEFT JOIN fraisforfait ff ON f.id_fichedeFrais = ff.id_fichedeFrais
        LEFT JOIN typefrais tf ON ff.id_typeFrais = tf.id_typeFrais
        WHERE f.id_utilisateur = @id_utilisateur
        AND f.AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')";
                    MySqlCommand forfaitCmd = new MySqlCommand(fraisForfaitQuery, conn);
                    forfaitCmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    MySqlDataReader forfaitReader = forfaitCmd.ExecuteReader();

                    Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                    PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                    document.Open();

                    Paragraph title = new Paragraph($"FICHE DE FRAIS DE {anneeMois.ToUpper()}", FontFactory.GetFont(FontFactory.HELVETICA, 16, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);

                    // Add user information
                    PdfPTable userInfoTable = new PdfPTable(2);
                    userInfoTable.WidthPercentage = 100;
                    userInfoTable.AddCell(CreateCell("Nom : " + nom, PdfPCell.ALIGN_LEFT));
                    userInfoTable.AddCell(CreateCell("Prénom : " + prenom, PdfPCell.ALIGN_LEFT));
                    userInfoTable.AddCell(CreateCell("État fiche : " + etat, PdfPCell.ALIGN_LEFT));
                    document.Add(userInfoTable);

                    // Add frais forfait section
                    Paragraph forfaitTitle = new Paragraph("VOS FRAIS FORFAITS", FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                    forfaitTitle.Alignment = Element.ALIGN_LEFT;
                    document.Add(forfaitTitle);

                    PdfPTable forfaitTable = new PdfPTable(3);
                    forfaitTable.WidthPercentage = 100;
                    forfaitTable.AddCell(CreateCell("Nom du frais", PdfPCell.ALIGN_CENTER, true));
                    forfaitTable.AddCell(CreateCell("Montant du frais", PdfPCell.ALIGN_CENTER, true));
                    forfaitTable.AddCell(CreateCell("État", PdfPCell.ALIGN_CENTER, true));

                    double totalForfait = 0;
                    while (forfaitReader.Read())
                    {
                        if (!forfaitReader.IsDBNull(forfaitReader.GetOrdinal("TypeFrai")))
                        {
                            forfaitTable.AddCell(CreateCell(forfaitReader["TypeFrai"].ToString(), PdfPCell.ALIGN_CENTER));
                            string montantTotal = forfaitReader["Montant_total"].ToString();
                            forfaitTable.AddCell(CreateCell(montantTotal, PdfPCell.ALIGN_CENTER));
                            forfaitTable.AddCell(CreateCell(forfaitReader["Etat"].ToString(), PdfPCell.ALIGN_CENTER));
                            totalForfait += Convert.ToDouble(montantTotal);
                        }
                    }
                    forfaitReader.Close();
                    document.Add(forfaitTable);

                    // Retrieve frais hors forfait
                    string fraisHorsForfaitQuery = @"
        SELECT hf.description, hf.montant, f.Etat
        FROM fichedefrais f
        LEFT JOIN fraishorsforfait hf ON f.id_fichedeFrais = hf.id_fichedeFrais
        WHERE f.id_utilisateur = @id_utilisateur
        AND f.AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')";
                    MySqlCommand horsForfaitCmd = new MySqlCommand(fraisHorsForfaitQuery, conn);
                    horsForfaitCmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    MySqlDataReader horsForfaitReader = horsForfaitCmd.ExecuteReader();

                    // Add frais hors forfait section
                    Paragraph horsForfaitTitle = new Paragraph("VOS FRAIS HORS FORFAITS", FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                    horsForfaitTitle.Alignment = Element.ALIGN_LEFT;
                    document.Add(horsForfaitTitle);

                    PdfPTable horsForfaitTable = new PdfPTable(3);
                    horsForfaitTable.WidthPercentage = 100;
                    horsForfaitTable.AddCell(CreateCell("Nom du frais", PdfPCell.ALIGN_CENTER, true));
                    horsForfaitTable.AddCell(CreateCell("Montant du frais", PdfPCell.ALIGN_CENTER, true));
                    horsForfaitTable.AddCell(CreateCell("État", PdfPCell.ALIGN_CENTER, true));

                    double totalHorsForfait = 0;
                    while (horsForfaitReader.Read())
                    {
                        if (!horsForfaitReader.IsDBNull(horsForfaitReader.GetOrdinal("description")))
                        {
                            horsForfaitTable.AddCell(CreateCell(horsForfaitReader["description"].ToString(), PdfPCell.ALIGN_CENTER));
                            string montant = horsForfaitReader["montant"].ToString();
                            horsForfaitTable.AddCell(CreateCell(montant, PdfPCell.ALIGN_CENTER));
                            horsForfaitTable.AddCell(CreateCell(horsForfaitReader["Etat"].ToString(), PdfPCell.ALIGN_CENTER));
                            totalHorsForfait += Convert.ToDouble(montant);
                        }
                    }
                    horsForfaitReader.Close();
                    document.Add(horsForfaitTable);

                    // Add recap section
                    Paragraph recapTitle = new Paragraph("RECAPITULATIF", FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                    recapTitle.Alignment = Element.ALIGN_LEFT;
                    document.Add(recapTitle);

                    PdfPTable recapTable = new PdfPTable(2);
                    recapTable.WidthPercentage = 50;
                    recapTable.AddCell(CreateCell("Total de vos frais forfaits :", PdfPCell.ALIGN_LEFT, true));
                    recapTable.AddCell(CreateCell($"{totalForfait.ToString("F2")} €", PdfPCell.ALIGN_RIGHT));
                    recapTable.AddCell(CreateCell("Total de vos frais hors forfaits :", PdfPCell.ALIGN_LEFT, true));
                    recapTable.AddCell(CreateCell($"{totalHorsForfait.ToString("F2")} €", PdfPCell.ALIGN_RIGHT));
                    recapTable.AddCell(CreateCell("Total de votre fiche de frais :", PdfPCell.ALIGN_LEFT, true));
                    recapTable.AddCell(CreateCell($"{(totalForfait + totalHorsForfait).ToString("F2")} €", PdfPCell.ALIGN_RIGHT));
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

        private void listViewForfait_SelectedIndexChanged(object sender, EventArgs e)
        {
        }




        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
