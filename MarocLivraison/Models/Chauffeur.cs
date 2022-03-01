using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarocLivraison.Models
{
    [Table("chauffeurs")]
    public class Chauffeur
    {
        public int ChauffeurID { get; set; }

        [Required(ErrorMessage = "CIN est requis"), MaxLength(10)]
        public string CIN { get; set; }

        [Required(ErrorMessage = "Nom Complet est requis"), MaxLength(50)]
        public string NomComplet { get; set; }

        [Required(ErrorMessage = "Numero Permis est requis"), MaxLength(20)]
        public string NumPermis { get; set; }
    }
}
