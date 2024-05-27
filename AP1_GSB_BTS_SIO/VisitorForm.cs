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
            listBoxFrais.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT f.id_fichedeFrais, f.AnneeMois, f.Etat, ff.id_fraisdeForfait, ff.Montant_total, ff.date, tf.TypeFrai
                FROM fichedefrais f
                LEFT JOIN fraisforfait ff ON f.id_fichedeFrais = ff.id_fichedeFrais
                LEFT JOIN typefrais tf ON ff.id_typeFrais = tf.id_typeFrais
                WHERE f.id_utilisateur = @id_utilisateur
                AND f.AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string expenseInfo = $"{reader["AnneeMois"]}, {reader["Etat"]}, {reader["TypeFrai"]}, {reader["Montant_total"]}";
                        listBoxFrais.Items.Add(expenseInfo);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
                    INSERT INTO fraishorsforfait (id_fichedeFrais, description, montant, date)
                    VALUES (
                        (SELECT id_fichedeFrais FROM fichedefrais WHERE id_utilisateur = @id_utilisateur AND AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')),
                        @description, @montant, NOW())";
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
                        (SELECT id_ficheFrais FROM fichedefrais WHERE id_utilisateur = @id_utilisateur AND AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')),
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
            listBoxFrais.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT f.AnneeMois, f.Etat, ff.description, ff.montant
                        FROM fichedefrais f
                        LEFT JOIN fraishorsforfait ff ON f.id_fichedeFrais = ff.id_fichedeFrais
                        WHERE f.id_utilisateur = @id_utilisateur
                        ORDER BY f.AnneeMois DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string expenseInfo = $"{reader["AnneeMois"]}, {reader["Etat"]}, {reader["description"]}, {reader["montant"]}";
                        listBoxFrais.Items.Add(expenseInfo);
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
                    string query = @"
                SELECT f.AnneeMois, f.Etat, ff.description, ff.montant
                FROM fichedefrais f
                LEFT JOIN fraishorsforfait ff ON f.id_fichedeFrais = ff.id_fichedeFrais
                WHERE f.id_utilisateur = @id_utilisateur
                AND f.AnneeMois = DATE_FORMAT(NOW(), '%Y-%m')";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    Document document = new Document();
                    PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                    document.Open();

                    document.Add(new Paragraph("Fiche de Frais"));
                    document.Add(new Paragraph(" "));

                    PdfPTable table = new PdfPTable(4);
                    table.AddCell("Mois");
                    table.AddCell("État");
                    table.AddCell("Description");
                    table.AddCell("Montant");

                    while (reader.Read())
                    {
                        table.AddCell(reader["AnneeMois"].ToString());
                        table.AddCell(reader["Etat"].ToString());
                        table.AddCell(reader["description"].ToString());
                        table.AddCell(reader["montant"].ToString());
                    }

                    document.Add(table);
                    document.Close();
                    MessageBox.Show("Fiche de frais exportée avec succès.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}
