namespace AP1_GSB_BTS_SIO.Models
{
    using System;
    public class FicheDeFrais
    {
        public int Id { get; set; }
        public string AnneeMois { get; set; }
        public int IdUtilisateur { get; set; }
        public int IdEtat { get; set; }
        public string Etat { get; set; }
    }
}