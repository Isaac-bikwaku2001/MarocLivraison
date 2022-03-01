using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarocLivraison.Models
{
    [Table("vehicules")]
    public class Vehicule
    {
        public int VehiculeID { get; set; }

        [Required(ErrorMessage = "Numero d'immatriculation est requis"), MaxLength(20)]
        public string NumImmatriculation { get; set; }

        [Required(ErrorMessage = "Marque est requis"), MaxLength(50)]
        public string Marque { get; set; }

        [Required(ErrorMessage = "Modèle est requis"), MaxLength(50)]
        public string Modele { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateMiseEnCirculation { get; set; }
        public int Kilometrage { get; set; }
    }
}
