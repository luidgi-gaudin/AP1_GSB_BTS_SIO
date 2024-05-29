using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class ForfaitDialog : Form
    {
        private string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";

        public int IdTypeFrais { get; set; }
        public decimal MontantTotal { get; set; }
        public int Quantite { get; set; }
        public string Date_frais { get; set; }
        public string AnneeMois { get; set; } // AnneeMois au format "yyyy-MM"

        public ForfaitDialog()
        {
            InitializeComponent();
        }

        private void ForfaitDialog_Load(object sender, EventArgs e)
        {
            LoadTypeFrais();
            // Set AnneeMois to the current month (you might want to change this logic depending on your needs)
            AnneeMois = DateTime.Now.ToString("yyyy-MM");
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
            DateTime selectedDate = dateTimePicker1.Value;

            if (IsValidFraisDate(selectedDate))
            {
                if (cmbTypeFrais.SelectedItem is ComboBoxItem selectedItem)
                {
                    IdTypeFrais = int.Parse(selectedItem.Value);
                    if (decimal.TryParse(selectedItem.Montant, out decimal montant) && int.TryParse(txtQuantite.Text, out int quantite))
                    {
                        MontantTotal = montant * quantite;
                        Quantite = int.Parse(txtQuantite.Text);
                        Date_frais = selectedDate.ToString("yyyy-MM-dd");
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
            else
            {
                MessageBox.Show("Date invalide. Veuillez sélectionner une date dans le mois actuel ou dans le mois précédent jusqu'au 10 du mois.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;

            if (IsValidFraisDate(selectedDate))
            {
                Date_frais = selectedDate.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Date invalide. Veuillez sélectionner une date dans le mois actuel ou dans le mois précédent jusqu'au 10 du mois.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidFraisDate(DateTime date)
        {
            DateTime firstDayOfMonth;
            if (DateTime.TryParseExact(AnneeMois + "-01", "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out firstDayOfMonth))
            {
                DateTime startRange = firstDayOfMonth.AddDays(10); // 11th of the month
                DateTime endRange = firstDayOfMonth.AddMonths(1).AddDays(9); // 10th of the next month

                return date >= startRange && date <= endRange;
            }
            return false;
        }
    }
}
