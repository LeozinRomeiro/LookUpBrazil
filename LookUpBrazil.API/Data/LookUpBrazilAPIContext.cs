using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LookUpBrazil.API.Models;
using LookUpBrazil.API.Data.Mappings;

namespace LookUpBrazil.API.Data
{
    public class LookUpBrazilAPIContext : DbContext
    {
        public LookUpBrazilAPIContext (DbContextOptions<LookUpBrazilAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LookUpBrazil.API.Models.Location> Locations { get; set; } = default!;

        public DbSet<LookUpBrazil.API.Models.User> Users { get; set; } = default!;
        public DbSet<LookUpBrazil.API.Models.Role> Roles { get; set; } = default!;
        public DbSet<LookUpBrazil.API.Models.Category> Categories { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
        }
    }
}
