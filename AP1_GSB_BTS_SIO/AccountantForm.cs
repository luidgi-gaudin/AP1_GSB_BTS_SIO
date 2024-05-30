using MySql.Data.MySqlClient;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class AccountantForm : Form
    {
        private string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";
        public AccountantForm()
        {
            InitializeComponent();
        }

        private void AccountantForm_Load(object sender, EventArgs e)
        {
            listViewFiche.Items.Clear();
            listViewDetails.Hide();
            label2.Show();
            btnApprove.Hide();
            btnReject.Hide();
            btnRejectReason.Hide();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT f.id_fichedeFrais, f.AnneeMois, e.etat , u.nom, u.prenom
                        FROM fichedefrais f
                        LEFT JOIN utilisateur u ON u.id_utilisateur = f.id_utilisateur
                        LEFT JOIN etat e ON e.id_etat = f.id_etat
                        WHERE f.id_etat = 1";
                    query += " ORDER BY AnneeMois DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string NomPrenom = reader["nom"].ToString() + " " + reader["prenom"].ToString();
                        ListViewItem item = new ListViewItem(reader["AnneeMois"].ToString());
                        item.Tag = reader["id_fichedeFrais"];
                        item.SubItems.Add(NomPrenom);
                        listViewFiche.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void ApproveExpenseReport(int expenseReportId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE fichedefrais SET id_etat = 3 WHERE id_fichedeFrais = @expenseReportId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@expenseReportId", expenseReportId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("La fiche de frais a bien été approuvée.");
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void RejectExpenseReport(int expenseReportId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE fichedefrais SET id_etat = 4 WHERE id_fichedeFrais = @expenseReportId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@expenseReportId", expenseReportId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("La fiche de frais a été Refusée.");
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ShowDetails(int expenseReportId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT tf.TypeFrai, ff.Montant_total, ff.date_frais
                FROM fichedefrais f
                LEFT JOIN fraisforfait ff ON ff.id_fichedefrais = f.id_fichedefrais
                LEFT JOIN typefrais tf ON tf.id_typefrais = ff.id_typefrais
                WHERE f.id_fichedeFrais = @expenseReportId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@expenseReportId", expenseReportId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    listViewDetails.Items.Clear();
                    listViewDetails.Show();
                    while (reader.Read())
                    {
                         ListViewItem itemForfait = new ListViewItem(reader["TypeFrai"].ToString());
                            itemForfait.SubItems.Add(reader["Montant_total"].ToString());
                            itemForfait.SubItems.Add(reader["date_frais"].ToString());
                            listViewDetails.Items.Add(itemForfait);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void ShowDetailsH(int expenseReportId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT fhf.description, fhf.montant, fhf.date_fraishors
                FROM fichedefrais f
                LEFT JOIN fraishorsforfait fhf ON fhf.id_fichedefrais = f.id_fichedefrais
                WHERE f.id_fichedeFrais = @expenseReportId"; ;
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@expenseReportId", expenseReportId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem itemForfait = new ListViewItem(reader["description"].ToString());
                        itemForfait.SubItems.Add(reader["montant"].ToString());
                        itemForfait.SubItems.Add(reader["date_fraishors"].ToString());
                        listViewDetails.Items.Add(itemForfait);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void listViewFiche_ItemActivate(object sender, EventArgs e)
        {
            if (listViewFiche.SelectedItems.Count > 0)
            {
                int expenseReportId = (int)listViewFiche.SelectedItems[0].Tag;
                ShowDetails(expenseReportId);
                ShowDetailsH(expenseReportId);
                label2.Hide();
                listViewDetails.Show();
                btnApprove.Show();
                btnReject.Show();
                btnRejectReason.Show();
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (listViewFiche.SelectedItems.Count > 0)
            {
                int expenseReportId = (int)listViewFiche.SelectedItems[0].Tag;
                ApproveExpenseReport(expenseReportId);
                AccountantForm_Load(sender, e); 

            }
            else
            {
                MessageBox.Show("Please select an expense report to approve.");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (listViewFiche.SelectedItems.Count > 0)
            {
                int expenseReportId = (int)listViewFiche.SelectedItems[0].Tag;
                RejectExpenseReport(expenseReportId);
                AccountantForm_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Please select an expense report to reject.");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
            this.Close();
        }

        private void RejectExpenseReportWithReason(int expenseReportId, string reason)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE fichedefrais SET id_etat = 6 WHERE id_fichedeFrais = @expenseReportId;" +
                        "INSERT INTO `motif_refus`( `motif`, `id_fichedeFrais`) VALUES (@reason, @expenseReportId)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@expenseReportId", expenseReportId);
                    cmd.Parameters.AddWithValue("@reason", reason);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expense report rejected with reason: " + reason);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void btnRejectReason_Click(object sender, EventArgs e)
        {
            if (listViewFiche.SelectedItems.Count > 0)
            {
                int expenseReportId = (int)listViewFiche.SelectedItems[0].Tag;
                string reason = Prompt.ShowDialog("entrez la raison du refus:", "Refuser avec une raison");
                if (!string.IsNullOrEmpty(reason))
                {
                    RejectExpenseReportWithReason(expenseReportId, reason);
                    AccountantForm_Load(sender, e); // Recharger les données après le rejet
                }
            }
            else
            {
                MessageBox.Show("Selectionnez une Fiche de frais pour effectuer une action.");
            }
        }
    }
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }

}
