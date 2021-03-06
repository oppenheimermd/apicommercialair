using apicommercialair.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace apicommercialair.data
{
    public class CommercialairDbContext : DbContext
    {
        public CommercialairDbContext(DbContextOptions<CommercialairDbContext> options) : base(options)
        {
        }

        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<AircraftImage> AircraftImages { get; set; }
    }
}
