using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRide.Models
{
    public class KundeDB : DbContext
    {
        public KundeDB(DbContextOptions<KundeDB> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Kunde> Kunder { get; set; }
    }
}
