using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AP1_GSB_BTS_SIO
{
    public partial class ForfaitDialog : Form
    {
        private string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";

        public int IdTypeFrais { get; set; }
        public decimal MontantTotal { get; set; }

        public ForfaitDialog()
        {
            InitializeComponent();
        }

        private void ForfaitDialog_Load(object sender, EventArgs e)
        {
            LoadTypeFrais();
        }

        private void LoadTypeFrais()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id_typeFrais, TypeFrai, montant FROM typefrais", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbTypeFrais.Items.Add(new ComboBoxItem(reader["TypeFrai"].ToString(), reader["id_typeFrais"].ToString(), reader["montant"].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbTypeFrais.SelectedItem is ComboBoxItem selectedItem)
            {
                IdTypeFrais = int.Parse(selectedItem.Value);
                if (decimal.TryParse(selectedItem.Montant, out decimal montant) && int.TryParse(txtQuantite.Text, out int quantite))
                {
                    MontantTotal = montant * quantite;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Veuillez entrer une quantité valide.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un type de frais.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private class ComboBoxItem
        {
            public string Text { get; }
            public string Value { get; }
            public string Montant { get; }

            public ComboBoxItem(string text, string value, string montant)
            {
                Text = text;
                Value = value;
                Montant = montant;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
