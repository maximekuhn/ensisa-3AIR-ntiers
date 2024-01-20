using JeBalance.Architecture.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Architecture.SQLite.Configurations;

public class DenonciationConfiguration : IEntityTypeConfiguration<DenonciationSQLite>
{
    public void Configure(EntityTypeBuilder<DenonciationSQLite> builder)
    {
        builder.ToTable("DENONCIATIONS")
            .HasKey(denonciation => denonciation.Id);

        // Dot not generate a Guid as the `IdOpaqueProvider` already does it
        builder.Property(denonciation => denonciation.Id).ValueGeneratedNever();


        // store enum as int
        builder.Property(denonciation => denonciation.TypeDelit).HasColumnType("int").IsRequired();
        builder.Property(denonciation => denonciation.Statut).HasColumnType("int").IsRequired();

        // Relations
        builder.HasOne(denonciation => denonciation.Informateur).WithMany().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(denonciation => denonciation.Suspect).WithMany().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(denonciation => denonciation.Reponse).WithOne().OnDelete(DeleteBehavior.NoAction);
    }
}