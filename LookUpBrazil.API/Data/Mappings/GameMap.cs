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

            builder.OwnsOne(g => g.SecretNames, sn =>
            {
                sn.ToTable("SecretNames");

                sn.HasOne(sn=>sn.Game);

                sn.OwnsMany(sn => sn.Names, n =>
                {
                    n.OwnsOne(s => s.Text, t =>
                    {
                        t.Property(text => text.TextCompleted)
                         .HasColumnName("Name")
                         .HasColumnType("varchar(80)")
                         .IsRequired();

                        t.Ignore(t => t.InitialLetter);
                    });
                });

            });

            builder.HasMany<SecretNames>().WithOne(e => e.Game);

            builder.OwnsOne(g => g.MatchedNames, mn =>
            {
                mn.ToTable("MatchedNames");

                mn.HasOne(mn => mn.Game);

                mn.OwnsMany(sn => sn.Names, n =>
                {
                    n.Property(n => n.Text.TextCompleted)
                     .HasColumnName("Name")
                     .HasColumnType("varchar(80)")
                     .IsRequired();
                    //n.OwnsOne(s => s.Text, t =>
                    //{
                    //    t.Property(text => text.TextCompleted)
                    //     .HasColumnName("Name")
                    //     .HasColumnType("varchar(80)")
                    //     .IsRequired();

                    //    t.Ignore(t => t.InitialLetter);
                    //});
                });
            });

        }
    }
}
