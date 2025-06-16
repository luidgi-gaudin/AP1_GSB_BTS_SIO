using MySql.Data.MySqlClient; // Importe la bibliothèque pour interagir avec MySQL
using System;
using System.Windows.Forms;

namespace AP1_GSB_BTS_SIO
{
    public partial class HistoryForm : Form
    {
        // Chaîne de connexion à la base de données MySQL
        // Contient les informations nécessaires pour se connecter au serveur MySQL
        private string connectionString = "server=localhost;user=root;database=ap1_gsb;port=3306;password=;";

        // Identifiant de l'utilisateur visiteur dont on affiche l'historique
        private int visitorId;

        /// <summary>
        /// Constructeur de la classe HistoryForm
        /// </summary>
        /// <param name="visitorId">ID de l'utilisateur visiteur</param>
        public HistoryForm(int visitorId)
        {
            // Initialise les composants graphiques du formulaire
            InitializeComponent();

            // Stocke l'ID du visiteur pour une utilisation ultérieure
            this.visitorId = visitorId;

            // Charge l'historique des fiches de frais du visiteur
            LoadHistory();
        }

        /// <summary>
        /// Charge les données d'historique des fiches de frais et les affiche dans le ListView
        /// </summary>
        /// <param name="anneeMois">Paramètre optionnel pour filtrer par année/mois</param>
        private void LoadHistory(string anneeMois = null)
        {
            // Efface tous les éléments actuellement affichés dans la liste
            listViewHistory.Items.Clear();

            // Utilise un bloc using pour garantir que les ressources de connexion sont libérées
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Ouvre la connexion à la base de données
                    conn.Open();

                    // Définit la requête SQL pour récupérer les fiches de frais
                    // Sélectionne l'ID de la fiche, la période (AnneeMois) et l'état de la fiche
                    string query = @"
                        SELECT f.id_fichedeFrais, f.AnneeMois, e.Etat
                        FROM fichedefrais f
                        LEFT JOIN etat e ON e.id_etat = f.id_etat
                        WHERE id_utilisateur = @id_utilisateur";

                    // Si un filtre anneeMois est fourni, ajoute une condition à la requête
                    if (!string.IsNullOrEmpty(anneeMois))
                    {
                        query += " AND AnneeMois LIKE @anneeMois";
                    }

                    // Ajoute un tri par ordre décroissant sur la colonne AnneeMois
                    query += " ORDER BY AnneeMois DESC";

                    // Crée une commande SQL avec la requête et la connexion
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Ajoute le paramètre pour l'ID utilisateur (protection contre l'injection SQL)
                    cmd.Parameters.AddWithValue("@id_utilisateur", visitorId);

                    // Si un filtre anneeMois est fourni, ajoute également ce paramètre
                    // Le % permet une recherche partielle (ex: "2023" trouvera "2023-01", "2023-02", etc.)
                    if (!string.IsNullOrEmpty(anneeMois))
                    {
                        cmd.Parameters.AddWithValue("@anneeMois", "%" + anneeMois + "%");
                    }

                    // Exécute la requête et récupère les résultats
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Parcourt chaque ligne de résultat
                    while (reader.Read())
                    {
                        // Crée un nouvel élément pour la ListView avec la valeur AnneeMois comme texte principal
                        ListViewItem item = new ListViewItem(reader["AnneeMois"].ToString());

                        // Stocke l'ID de la fiche de frais dans la propriété Tag pour utilisation ultérieure
                        item.Tag = reader["id_fichedeFrais"];

                        // Ajoute la valeur de l'état comme sous-élément
                        item.SubItems.Add(reader["Etat"].ToString());

                        // Ajoute l'élément complet à la ListView
                        listViewHistory.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    // Affiche un message d'erreur si une exception se produit
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Gestionnaire d'événement déclenché lorsqu'un élément de la liste est activé (double-clic)
        /// </summary>
        private void ListViewHistory_ItemActivate(object sender, EventArgs e)
        {
            // Vérifie si un élément est sélectionné
            if (listViewHistory.SelectedItems.Count > 0)
            {
                // Récupère l'ID de la fiche de frais stocké dans la propriété Tag
                int ficheDeFraisId = (int)listViewHistory.SelectedItems[0].Tag;

                // Crée et affiche un formulaire de détail pour cette fiche de frais
                // Le using garantit que le formulaire sera correctement fermé et libéré
                using (DetailForm detailForm = new DetailForm(ficheDeFraisId))
                {
                    // Affiche le formulaire en mode modal (bloque l'interaction avec le formulaire parent)
                    detailForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Gestionnaire d'événement pour le bouton de recherche
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Récupère le texte saisi dans le champ de recherche et supprime les espaces
            string anneeMois = txtSearch.Text.Trim();

            // Recharge l'historique avec le filtre de recherche
            LoadHistory(anneeMois);
        }

        /// <summary>
        /// Gestionnaire d'événement déclenché lors du chargement initial du formulaire
        /// </summary>
        private void HistoryForm_Load(object sender, EventArgs e)
        {
            // Cette méthode est vide mais pourrait être utilisée pour 
            // des initialisations supplémentaires au chargement du formulaire
        }
    }
}