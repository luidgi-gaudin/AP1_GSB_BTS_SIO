using System;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class HorsForfaitDialog : Form
    {
        public string Description { get; set; }
        public decimal Montant { get; set; }
        public string Date_frais { get; set; }
        public string AnneeMois { get; set; } // AnneeMois au format "yyyy-MM"

        public HorsForfaitDialog()
        {
            InitializeComponent();
        }

        private void HorsForfaitDialog_Load(object sender, EventArgs e)
        {
            // Set AnneeMois to the current month (you might want to change this logic depending on your needs)
            AnneeMois = DateTime.Now.ToString("yyyy-MM");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;

            if (IsValidFraisDate(selectedDate))
            {
                Description = txtDescription.Text;
                if (decimal.TryParse(txtMontant.Text, out decimal montant))
                {
                    Montant = montant;
                    Date_frais = selectedDate.ToString("yyyy-MM-dd");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Veuillez entrer un montant valide.");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
