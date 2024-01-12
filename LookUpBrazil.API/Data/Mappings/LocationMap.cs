using LookUpBrazil.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LookUpBrazil.API.Data.Mappings
{
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable(nameof(Location));
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd()
            //    .UseIdentityColumn();

            builder.Property(x => x.State).IsRequired().HasColumnName("State").HasColumnType("VARCHAR").HasMaxLength(2);

            builder.Property(x => x.City).IsRequired().HasColumnName("City").HasColumnType("VARCHAR").HasMaxLength(80);

            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x=>x.Category)
                .WithMany(x=>x.Locations)
                .HasConstraintName("FK_Location_Category")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
