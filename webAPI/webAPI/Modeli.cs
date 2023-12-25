using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace webAPI
{
    public class Uporabnik
    {
        
        public int id { get; set; }

        public string ime { get; set; }
        public string email { get; set; }
        public string Role { get; set; }
    }

    public class Log
    {
        public int Id { get; set; }
        public DateTime CasovnaZnacka { get; set; }
        public string StopnjaResnosti { get; set; }
        public string Vsebina { get; set; }
        public string Izvor { get; set; }
        public int ProjektId { get; set; }
        public int UporabnikId { get; set; } 
    }


    public class Projekt
    {
        public int Id { get; set; }
        public string ImeProjekta { get; set; }
        public int UporabnikId { get; set; } 
    }


    public class ApplicationDbContext : DbContext
    {
        public DbSet<Uporabnik> Uporabnik { get; set; }

        public DbSet<Log> Log { get; set; }

        public DbSet<Projekt> Projekt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-4GN3RDJ;Database=API;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true;User Id=DESKTOP-4GN3RDJ\\Uporabnik;");

        }
    }
}
