using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LookUpBrazil.API.Models;

namespace LookUpBrazil.API.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnName("Name").HasColumnType("VARCHAR").HasMaxLength(80);
            builder.Property(x => x.Email).IsRequired().HasColumnName("Email").HasColumnType("VARCHAR").HasMaxLength(160);
            builder.Property(x => x.PasswordHash).IsRequired().HasColumnName("PasswordHash").HasColumnName("PasswordHash").HasColumnType("VARCHAR").HasMaxLength(256);
        }
    }
}
