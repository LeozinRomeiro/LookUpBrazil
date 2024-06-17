using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LookUpBrazil.Api.Data.Mappings
{
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable(nameof(Game));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.OwnsOne(x => x.Requirement, requirement =>
            {
                requirement.OwnsOne(x => x.InitialLetter, initialLetter =>
                {
                    initialLetter.Property(n => n.Text)
                    .HasColumnName("InitialLetter")
                    .IsRequired()
                    .HasColumnName("Letter")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(1);
                });
            });
        }
    }
}
