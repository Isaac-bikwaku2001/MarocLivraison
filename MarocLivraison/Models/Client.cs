using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarocLivraison.Models
{
    [Table("clients")]
    public class Client
    {
        public int ClientID { get; set; }

        [Required(ErrorMessage = "La raison sociale est requis"), MaxLength(100)]
        public string RaisonSociale { get; set; }

        [Required(ErrorMessage = "Nom du responsable est requis"), MaxLength(50)]
        public string NomResponsable { get; set; }
    }
}
