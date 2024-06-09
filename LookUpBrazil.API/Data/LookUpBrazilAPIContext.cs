using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LookUpBrazil.Api.Data.Mappings;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Entities;

namespace LookUpBrazil.Api.Data
{
    public class LookUpBrazilApiContext : DbContext
    {
        public LookUpBrazilApiContext (DbContextOptions<LookUpBrazilApiContext> options)
            : base(options)
        {
        }

        public DbSet<LookUpBrazil.Api.Models.Location> Locations { get; set; } = default!;

        public DbSet<LookUpBrazil.Api.Models.User> Users { get; set; } = default!;
        public DbSet<LookUpBrazil.Api.Models.Role> Roles { get; set; } = default!;
        public DbSet<LookUpBrazil.Api.Models.Category> Categories { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;
        public DbSet<Game> Games { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new CityMap());
        }
    }
}
