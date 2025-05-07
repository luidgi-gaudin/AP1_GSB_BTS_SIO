using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using AP1_GSB_BTS_SIO.Models;
using System;

namespace AP1_GSB_BTS_SIO.Services
{
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
                                Id = reader.IsDBNull(reader.GetOrdinal("id_fraisForfait"))
                                    ? 0
                                    : reader.GetInt32("id_fraisForfait"),
                                FicheDeFraisId = reader.IsDBNull(reader.GetOrdinal("id_fichedeFrais"))
                                    ? 0
                                    : reader.GetInt32("id_fichedeFrais"),
                                TypeFrai = reader.IsDBNull(reader.GetOrdinal("TypeFrai"))
                                    ? ""
                                    : reader.GetString("TypeFrai"),
                                Montant = reader.IsDBNull(reader.GetOrdinal("Montant_total"))
                                    ? 0
                                    : reader.GetDecimal("Montant_total"),
                                Quantite = reader.IsDBNull(reader.GetOrdinal("quantite"))
                                    ? 0
                                    : reader.GetInt32("quantite"),
                                DateFrais = reader.IsDBNull(reader.GetOrdinal("date_frais"))
                                    ? DateTime.MinValue
                                    : reader.GetDateTime("date_frais"),
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
// À placer dans la classe DetailFraisService
public int InsertForfait(DetailFrais frais)
{
    var sql = @"INSERT INTO fraisforfait (id_fichedeFrais, id_typeFrais, Montant_total, date_frais, quantite)
                VALUES (@fiche, @type, @montant, @date, @quantite)";
    return InsertDetail(sql, frais);
}

public int InsertHorsForfait(DetailFrais frais)
{
    var sql = @"INSERT INTO fraishorsforfait (id_fichedeFrais, montant, date_fraishors, description)
                VALUES (@fiche, @montant, @date, @desc)";
    using (var conn = new MySqlConnection(_connectionString))
    {
        conn.Open();
        using (var cmd = new MySqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@fiche",   frais.FicheDeFraisId);
            cmd.Parameters.AddWithValue("@montant", frais.Montant);
            cmd.Parameters.AddWithValue("@date",    frais.DateFrais);
            cmd.Parameters.AddWithValue("@desc",    frais.TypeFrai);
            cmd.ExecuteNonQuery();
            return (int)cmd.LastInsertedId;
        }
    }
}

public void UpdateForfait(DetailFrais frais)
{
    string sql = @"UPDATE fraisforfait SET Montant_total=@montant, date_frais=@date, quantite=@quantite
                   WHERE id_fraisForfait=@id";
    ExecUpdateForfait(sql, frais);
}

public void DeleteForfait(int idFraisForfait)
{
    ExecDelete("DELETE FROM fraisforfait WHERE id_fraisForfait=@id", idFraisForfait);
}

public void UpdateHorsForfait(DetailFrais frais)
{
    string sql = @"UPDATE fraishorsforfait SET montant=@montant, date_fraishors=@date, description=@desc
                   WHERE id_fraisHorsForfait=@id";
    ExecUpdateHors(sql, frais);
}

public void DeleteHorsForfait(int idFraisHF)
{
    ExecDelete("DELETE FROM fraishorsforfait WHERE id_fraisHorsForfait=@id", idFraisHF);
}

/* -----------------------  Méthodes privées  ------------------------ */

private int InsertDetail(string sql, DetailFrais frais)
{
    using (var conn = new MySqlConnection(_connectionString))
    {
        conn.Open();
        using (var cmd = new MySqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@fiche",    frais.FicheDeFraisId);
            cmd.Parameters.AddWithValue("@type",     frais.TypeFrai);
            cmd.Parameters.AddWithValue("@montant",  frais.Montant);
            cmd.Parameters.AddWithValue("@date",     frais.DateFrais);
            cmd.Parameters.AddWithValue("@quantite", frais.Quantite);
            cmd.ExecuteNonQuery();
            return (int)cmd.LastInsertedId;
        }
    }
}

private void ExecUpdateForfait(string sql, DetailFrais frais)
{
    using (var conn = new MySqlConnection(_connectionString))
    {
        conn.Open();
        using (var cmd = new MySqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@montant",  frais.Montant);
            cmd.Parameters.AddWithValue("@date",     frais.DateFrais);
            cmd.Parameters.AddWithValue("@quantite", frais.Quantite);
            cmd.Parameters.AddWithValue("@id",       frais.Id);
            cmd.ExecuteNonQuery();
        }
    }
}

private void ExecUpdateHors(string sql, DetailFrais frais)
{
    using (var conn = new MySqlConnection(_connectionString))
    {
        conn.Open();
        using (var cmd = new MySqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@montant", frais.Montant);
            cmd.Parameters.AddWithValue("@date",    frais.DateFrais);
            cmd.Parameters.AddWithValue("@desc",    frais.TypeFrai);
            cmd.Parameters.AddWithValue("@id",      frais.Id);
            cmd.ExecuteNonQuery();
        }
    }
}

private void ExecDelete(string sql, int id)
{
    using (var conn = new MySqlConnection(_connectionString))
    {
        conn.Open();
        using (var cmd = new MySqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
    }
}