using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class HistoryForm : Form
    {
        private string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";
        private int visitorId;

        public HistoryForm(int visitorId)
        {
            InitializeComponent();
            this.visitorId = visitorId;
            LoadHistory();
        }

        private void LoadHistory(string anneeMois = null)
        {
            listViewHistory.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT f.id_fichedeFrais, f.AnneeMois, e.Etat
                        FROM fichedefrais f
                        LEFT JOIN etat e ON e.id_etat = f.id_etat
                        WHERE id_utilisateur = @id_utilisateur";
                    if (!string.IsNullOrEmpty(anneeMois))
                    {
                        query += " AND AnneeMois LIKE @anneeMois";
                    }
                    query += " ORDER BY AnneeMois DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);
                    if (!string.IsNullOrEmpty(anneeMois))
                    {
                        cmd.Parameters.AddWithValue("@anneeMois", "%" + anneeMois + "%");
                    }
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["AnneeMois"].ToString());
                        item.Tag = reader["id_fichedeFrais"];
                        item.SubItems.Add(reader["Etat"].ToString());
                        listViewHistory.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ListViewHistory_ItemActivate(object sender, EventArgs e)
        {
            if (listViewHistory.SelectedItems.Count > 0)
            {
                int ficheDeFraisId = (int)listViewHistory.SelectedItems[0].Tag;
                using (DetailForm detailForm = new DetailForm(ficheDeFraisId))
                {
                    detailForm.ShowDialog();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string anneeMois = txtSearch.Text.Trim();
            LoadHistory(anneeMois);
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
