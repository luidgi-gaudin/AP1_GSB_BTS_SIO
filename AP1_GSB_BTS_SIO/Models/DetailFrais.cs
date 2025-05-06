namespace AP1_GSB_BTS_SIO.Models
{
    using System;
    public class DetailFrais
    {
        public int Id { get; set; }
        public int FicheDeFraisId { get; set; }
        public string TypeFrai { get; set; }
        public decimal Montant { get; set; }
        public int Quantite { get; set; }
        public DateTime DateFrais { get; set; }
    }
}