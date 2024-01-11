using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LookUpBrazil.API.Models;

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
    }
}
