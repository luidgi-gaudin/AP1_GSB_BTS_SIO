using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class DetailForm : Form
    {
        private string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";
        private int ficheDeFraisId;

        public DetailForm(int ficheDeFraisId)
        {
            InitializeComponent();
            this.ficheDeFraisId = ficheDeFraisId;
            LoadDetails();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

        private void LoadDetails()
        {
            listViewForfait.Items.Clear();
            listViewHorsForfait.Items.Clear();

            // Load frais forfait
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT tf.TypeFrai, ff.Montant_total, ff.quantite, DATE_FORMAT(ff.date_frais, '%Y-%m-%d') AS date_frais
                        FROM fraisforfait ff
                        JOIN typefrais tf ON ff.id_typeFrais = tf.id_typeFrais
                        WHERE ff.id_fichedeFrais = @id_fichedeFrais";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_fichedeFrais", ficheDeFraisId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["TypeFrai"].ToString());
                        item.SubItems.Add(reader["quantite"].ToString());
                        item.SubItems.Add(reader["Montant_total"].ToString());
                        item.SubItems.Add(reader["date_frais"].ToString());
                        listViewForfait.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des frais forfait : " + ex.Message);
                }
            }

            // Load frais hors forfait
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT description, montant, DATE_FORMAT(date_fraishors, '%Y-%m-%d') AS date_fraishors
                        FROM fraishorsforfait
                        WHERE id_fichedeFrais = @id_fichedeFrais";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_fichedeFrais", ficheDeFraisId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["description"].ToString());
                        item.SubItems.Add(reader["montant"].ToString());
                        item.SubItems.Add(reader["date_fraishors"].ToString());
                        listViewHorsForfait.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des frais hors forfait : " + ex.Message);
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
                    // Retrieve user and fiche info
                    string userInfoQuery = @"
                        SELECT u.nom, u.prenom, f.AnneeMois, e.etat
                        FROM fichedefrais f
                        JOIN utilisateur u ON f.id_utilisateur = u.id_utilisateur
                        JOIN etat e ON f.id_etat = e.id_etat
                        WHERE f.id_fichedeFrais = @id_fichedeFrais";
                    MySqlCommand userInfoCmd = new MySqlCommand(userInfoQuery, conn);
                    userInfoCmd.Parameters.AddWithValue("@id_fichedeFrais", ficheDeFraisId);
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

                    // Add logo
                    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gsb_logo.png");
                    if (File.Exists(imagePath))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imagePath);
                        logo.ScaleToFit(100, 50);
                        logo.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                        document.Add(logo);
                    }

                    // Add title
                    Paragraph title = new Paragraph($"FICHE DE FRAIS DE {anneeMois.ToUpper()}", FontFactory.GetFont(FontFactory.HELVETICA, 16, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);

                    Paragraph createdOn = new Paragraph($"Créée le : {DateTime.Now.ToString("dd/MM/yyyy")}", FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.ITALIC));
                    createdOn.Alignment = Element.ALIGN_RIGHT;
                    document.Add(createdOn);

                    // Add user information
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
                    userInfoTable.AddCell(CreateCell($"Date de création fiche : {dateCreation}", PdfPCell.ALIGN_LEFT));
                    userInfoTable.AddCell(CreateCell($"État fiche : {etat}", PdfPCell.ALIGN_LEFT));
                    document.Add(userInfoTable);

                    // Add frais forfait section
                    Paragraph forfaitTitle = new Paragraph("VOS FRAIS FORFAITS", FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                    forfaitTitle.Alignment = Element.ALIGN_LEFT;
                    document.Add(forfaitTitle);

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
                        JOIN typefrais tf ON ff.id_typeFrais = tf.id_typeFrais
                        WHERE ff.id_fichedeFrais = @id_fichedeFrais";
                    MySqlCommand forfaitCmd = new MySqlCommand(fraisForfaitQuery, conn);
                    forfaitCmd.Parameters.AddWithValue("@id_fichedeFrais", ficheDeFraisId);
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

                    // Add frais hors forfait section
                    Paragraph horsForfaitTitle = new Paragraph("VOS FRAIS HORS FORFAITS", FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                    horsForfaitTitle.Alignment = Element.ALIGN_LEFT;
                    document.Add(horsForfaitTitle);

                    PdfPTable horsForfaitTable = new PdfPTable(3);
                    horsForfaitTable.WidthPercentage = 100;
                    horsForfaitTable.AddCell(CreateCell("Date du frais", PdfPCell.ALIGN_CENTER, true));
                    horsForfaitTable.AddCell(CreateCell("Nom du frais", PdfPCell.ALIGN_CENTER, true));
                    horsForfaitTable.AddCell(CreateCell("Montant du frais", PdfPCell.ALIGN_CENTER, true));

                    double totalHorsForfait = 0;

                    string fraisHorsForfaitQuery = @"
                        SELECT description, montant, DATE_FORMAT(date_fraishors, '%d/%m/%Y') AS date_fraishors
                        FROM fraishorsforfait
                        WHERE id_fichedeFrais = @id_fichedeFrais";
                    MySqlCommand horsForfaitCmd = new MySqlCommand(fraisHorsForfaitQuery, conn);
                    horsForfaitCmd.Parameters.AddWithValue("@id_fichedeFrais", ficheDeFraisId);
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

        private void DetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
