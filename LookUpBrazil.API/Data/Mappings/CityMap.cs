using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LookUpBrazil.Core.ObjectValues;

namespace LookUpBrazil.Api.Data.Mappings
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City));
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd()
            //    .UseIdentityColumn();

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(n => n.TextCompleted)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(80);
            });

            builder.OwnsOne(x => x.States, states =>
            {
                states.Property(n => n.Acronym)
                    .IsRequired()
                    .HasColumnName("States")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(2);
            });
        }
    }
}
