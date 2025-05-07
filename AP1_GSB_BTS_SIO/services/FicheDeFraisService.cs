
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using AP1_GSB_BTS_SIO.Models;
using System;
using System.Linq;

namespace AP1_GSB_BTS_SIO.Services
{
    public class FicheDeFraisService
    {
        private readonly string _connectionString;

        public FicheDeFraisService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<FicheDeFrais> GetFicheDeFraisActuelle(int idUtilisateur, string anneeMois)
        {
            var result = new List<FicheDeFrais>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT f.id_fichedeFrais, f.AnneeMois, f.id_utilisateur, f.id_etat, e.etat
                    FROM fichedefrais f LEFT JOIN etat e ON f.id_etat = e.id_etat
                    WHERE id_utilisateur = @idUtilisateur
                    AND AnneeMois LIKE @anneeMois";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);
                    cmd.Parameters.AddWithValue("@anneeMois", anneeMois);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new FicheDeFrais
                            {
                                Id = reader.IsDBNull(reader.GetOrdinal("id_fichedeFrais"))
                                    ? 0
                                    : reader.GetInt32("id_fichedeFrais"),
                                AnneeMois = reader.IsDBNull(reader.GetOrdinal("AnneeMois"))
                                    ? ""
                                    : reader.GetString("AnneeMois"),
                                IdUtilisateur = reader.IsDBNull(reader.GetOrdinal("id_utilisateur"))
                                    ? 0
                                    : reader.GetInt32("id_utilisateur"),
                                IdEtat = reader.IsDBNull(reader.GetOrdinal("id_etat")) ? 0 : reader.GetInt32("id_etat"),
                                Etat = reader.IsDBNull(reader.GetOrdinal("etat")) ? "" : reader.GetString("etat"),
                            });
                        }
                    }
                }
            }

            return result;
        }

        public FicheDeFrais GetOrCreateFicheDeFrais(int idUtilisateur, string anneeMois)
        {
            // 1) Recherche
            var fiche = GetFicheDeFraisActuelle(idUtilisateur, anneeMois).FirstOrDefault();
            if (fiche != null) return fiche;

            // 2) Création si inexistant
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string insert = @"INSERT INTO fichedefrais (AnneeMois, id_utilisateur, id_etat)
                          VALUES (@anneeMois, @idUtilisateur, @etat)";
                using (var cmd = new MySqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@anneeMois", anneeMois);
                    cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);
                    cmd.Parameters.AddWithValue("@etat", (int)EtatFiche.EN_ATTENTE);
                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.LastInsertedId;
                    return new FicheDeFrais
                    {
                        Id = id,
                        AnneeMois = anneeMois,
                        IdUtilisateur = idUtilisateur,
                        IdEtat = (int)EtatFiche.EN_ATTENTE,
                        Etat = EtatFiche.EN_ATTENTE.ToString()
                    };
                }
            }
        }

        public void ChangerEtat(int ficheId, EtatFiche nouvelEtat)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string update = "UPDATE fichedefrais SET id_etat = @etat WHERE id_fichedeFrais = @id";
                using (var cmd = new MySqlCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@etat", (int)nouvelEtat);
                    cmd.Parameters.AddWithValue("@id", ficheId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}