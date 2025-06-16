using System;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    /// <summary>
    /// Boîte de dialogue permettant la saisie des frais hors forfait
    /// </summary>
    public partial class HorsForfaitDialog : Form
    {
        // Propriétés publiques pour stocker les données saisies par l'utilisateur

        /// <summary>
        /// Description du frais hors forfait saisi par l'utilisateur
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Montant du frais hors forfait (valeur décimale)
        /// </summary>
        public decimal Montant { get; set; }

        /// <summary>
        /// Date du frais au format "yyyy-MM-dd"
        /// </summary>
        public string Date_frais { get; set; }

        /// <summary>
        /// Période (année-mois) associée au format "yyyy-MM"
        /// </summary>
        public string AnneeMois { get; set; } // AnneeMois au format "yyyy-MM"

        /// <summary>
        /// Constructeur de la boîte de dialogue
        /// </summary>
        public HorsForfaitDialog()
        {
            // Initialise les composants graphiques de la boîte de dialogue
            InitializeComponent();
        }

        /// <summary>
        /// Événement déclenché au chargement de la boîte de dialogue
        /// </summary>
        private void HorsForfaitDialog_Load(object sender, EventArgs e)
        {
            // Initialise la période (année-mois) avec le mois courant
            // Exemple: si nous sommes en mai 2023, AnneeMois sera "2023-05"
            AnneeMois = DateTime.Now.ToString("yyyy-MM");
        }

        /// <summary>
        /// Gestionnaire d'événement pour le bouton OK
        /// Valide les données saisies et ferme la boîte de dialogue si valides
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Récupère la date sélectionnée par l'utilisateur
            DateTime selectedDate = dateTimePicker1.Value;

            // Vérifie si la date est valide selon les règles métier
            if (IsValidFraisDate(selectedDate))
            {
                // Récupère la description du frais
                Description = txtDescription.Text;

                // Tente de convertir le texte du montant en valeur décimale et vérifie qu'il est positif
                if (decimal.TryParse(txtMontant.Text, out decimal montant) && montant > 0)
                {
                    // Si la conversion réussit et que le montant est valide,
                    // stocke les données et ferme la boîte de dialogue avec le résultat OK
                    Montant = montant;
                    Date_frais = selectedDate.ToString("yyyy-MM-dd");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    // Affiche un message d'erreur si le montant n'est pas valide
                    MessageBox.Show("Veuillez entrer un montant valide ou supérieur à 0.");
                }
            }
            else
            {
                // Affiche un message d'erreur si la date n'est pas valide selon les règles métier
                MessageBox.Show(
                    "Date invalide. Veuillez sélectionner une date dans le mois actuel ou dans le mois précédent jusqu'au 10 du mois.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gestionnaire d'événement pour le bouton Annuler
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Définit le résultat de la boîte de dialogue comme Annulé et ferme la fenêtre
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Vérifie si la date du frais est valide selon les règles métier
        /// Une date est valide si elle se trouve entre :
        /// - le 11 du mois en cours (premier jour du mois + 10 jours)
        /// - et le 10 du mois suivant (premier jour du mois suivant + 9 jours)
        /// </summary>
        /// <param name="date">Date à vérifier</param>
        /// <returns>True si la date est valide, False sinon</returns>
        private bool IsValidFraisDate(DateTime date)
        {
            // Variable pour stocker le premier jour du mois courant
            DateTime firstDayOfMonth;

            // Tente de convertir AnneeMois + "-01" en objet DateTime
            // Par exemple, "2023-05" devient "2023-05-01"
            if (DateTime.TryParseExact(AnneeMois + "-01", "yyyy-MM-dd", null,
                    System.Globalization.DateTimeStyles.None, out firstDayOfMonth))
            {
                // Calcule la date de début de la plage valide (le 11 du mois courant)
                DateTime startRange = firstDayOfMonth.AddDays(10);

                // Calcule la date de fin de la plage valide (le 10 du mois suivant)
                DateTime endRange = firstDayOfMonth.AddMonths(1).AddDays(9);

                // Vérifie si la date est dans la plage valide
                return date >= startRange && date <= endRange;
            }

            // Si la conversion a échoué, retourne false
            return false;
        }

        /// <summary>
        /// Gestionnaire d'événement pour le clic sur un label (non utilisé)
        /// </summary>
        private void label1_Click(object sender, EventArgs e)
        {
            // Cette méthode est vide
            // Elle a probablement été générée automatiquement lors de la création de l'interface
            // mais n'est pas utilisée dans la logique de l'application
        }
    }
}