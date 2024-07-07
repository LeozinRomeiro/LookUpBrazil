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
                    initialLetter.Property(n => n.Character)
                    .HasColumnName("InitialLetter")
                    .IsRequired()
                    .HasColumnName("Letter")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(1);
                });
            });

            builder.OwnsMany(e => e.SecretNames, sn =>
            {
                sn.WithOwner().HasForeignKey("GameId");
                sn.Property<int>("Id");
                sn.HasKey("Id");
                sn.ToTable("GameSecretNames");
                sn.Property(t => t.TextCompleted)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(80);

                sn.Ignore(t => t.InitialLetter);
            });

            builder.OwnsMany(e => e.MatchedNames, mn =>
            {
                mn.Property(t => t.TextCompleted)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(80);

                mn.Ignore(t => t.InitialLetter);
                mn.WithOwner().HasForeignKey("GameId");
                mn.Property<int>("Id");
                mn.HasKey("Id");
                mn.ToTable("GameMatchedNames");
            });

        }
    }
}
