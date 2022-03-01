using MarocLivraison.Models;
using Microsoft.EntityFrameworkCore;

namespace MarocLivraison.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Chauffeur> Chauffeurs { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }
        public DbSet<Tournees> Tournees { get; set; }
    }
}
