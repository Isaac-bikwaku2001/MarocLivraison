using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarocLivraison.Models
{
    [Table("tournees")]
    public class Tournees
    {
        public int TourneesID { get; set; }

        [ForeignKey("Chauffeur")]
        public int ChauffeurID { get; set; }
        public Chauffeur Chauffeur { get; set; }

        [ForeignKey("Vehicule")]
        public int VehiculeID { get; set; }
        public Vehicule Vehicule { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public Client Client { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateLivraison { get; set; }
        public int Kilometrage { get; set; }
        public int NiveauCarburant { get; set; }
        public string AdresseLivraison { get; set; }
        public int DureeLivraison { get; set; }
    }
}
