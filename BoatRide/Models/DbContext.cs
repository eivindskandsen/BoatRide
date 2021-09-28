using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRide.Models
{
    public class Kunde
    {
        [Key]
        public int KId { get; set; }
        public string forNavn { get; set; }
        public string etterNavn { get; set; }
        public string epost { get; set; }
        public virtual List<Billett> Billetter { get; set; }
    }

    public class Billett
    {
        [Key]
        public int BId { get; set; }
        public string fra { get; set; }

        public string til { get; set; }

        public int antall { get; set; }

        public int dag { get; set; }

        public int måned { get; set; }

        public int år { get; set; }

    }

    public class BoatContext : DbContext
    {
        public BoatContext(DbContextOptions<BoatContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Kunde> Kunder { get; set; }

        public DbSet<Billett> Billetter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
