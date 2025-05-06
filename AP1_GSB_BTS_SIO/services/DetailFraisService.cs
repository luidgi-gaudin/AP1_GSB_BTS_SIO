// Services/DetailFraisService.cs

using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using AP1_GSB_BTS_SIO.Models;
using System;

public class DetailFraisService
{
    private readonly string _connectionString;

    public DetailFraisService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<DetailFrais> GetDetailsForfaitByFiche(int ficheDeFraisId)
    {
        var result = new List<DetailFrais>();
        using (var conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            string query = @"
                SELECT d.id_fraisForfait, d.id_fichedeFrais, t.TypeFrai, d.Montant_total, d.date_frais, d.quantite
                FROM fraisforfait d
                JOIN TypeFrais t ON d.id_typeFrais = t.id_typeFrais
                WHERE d.id_fichedeFrais = @ficheDeFraisId";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ficheDeFraisId", ficheDeFraisId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new DetailFrais
                        {
                            Id = reader.IsDBNull(reader.GetOrdinal("id_fraisForfait")) ? 0 : reader.GetInt32("id_fraisForfait"),
                            FicheDeFraisId = reader.IsDBNull(reader.GetOrdinal("id_fichedeFrais")) ? 0 : reader.GetInt32("id_fichedeFrais"),
                            TypeFrai = reader.IsDBNull(reader.GetOrdinal("TypeFrai")) ? "" : reader.GetString("TypeFrai"),
                            Montant = reader.IsDBNull(reader.GetOrdinal("Montant_total")) ? 0 : reader.GetDecimal("Montant_total"),
                            Quantite = reader.IsDBNull(reader.GetOrdinal("quantite")) ? 0 : reader.GetInt32("quantite"),
                            DateFrais = reader.IsDBNull(reader.GetOrdinal("date_frais")) ? DateTime.MinValue : reader.GetDateTime("date_frais"),
                        });
                    }
                }
            }
        }

        return result;
    }
    public List<DetailFrais> GetDetailsHorsForfaitByFiche(int ficheDeFraisId)
    {
        var result = new List<DetailFrais>();
        using (var conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            string query = @"
                SELECT id_fraisHorsForfait, id_fichedeFrais, montant, date_fraishors, description
                FROM fraishorsforfait 
                WHERE id_fichedeFrais = @ficheDeFraisId";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ficheDeFraisId", ficheDeFraisId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new DetailFrais
                        {
                            Id = reader.GetInt32("id_fraisHorsForfait"),
                            FicheDeFraisId = reader.GetInt32("id_fichedeFrais"),
                            Montant = reader.GetDecimal("montant"),
                            TypeFrai = reader.GetString("description"),
                            DateFrais = reader.GetDateTime("date_fraishors"),
                        });
                    }
                }
            }
        }

        return result;
    }
}