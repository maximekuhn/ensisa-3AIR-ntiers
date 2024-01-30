using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Infrastructure.SQLite.Configurations;

public class DenonciationConfiguration : IEntityTypeConfiguration<DenonciationSQLite>
{
    public void Configure(EntityTypeBuilder<DenonciationSQLite> builder)
    {
        builder.ToTable("DENONCIATIONS")
            .HasKey(denonciation => denonciation.Id);

        // Dot not generate a Guid as the `IdOpaqueProvider` already does it
        builder.Property(denonciation => denonciation.Id).ValueGeneratedNever();

        // required properties
        builder.Property(denonciation => denonciation.Horodatage).IsRequired();
        builder.Property(denonciation => denonciation.IdInformateur).IsRequired();
        builder.Property(denonciation => denonciation.IdSuspect).IsRequired();
        
        
        // store enum as int
        builder.Property(denonciation => denonciation.TypeDelit).HasColumnType("int").IsRequired();

        // Relations
        builder.HasOne(denonciation => denonciation.Informateur).WithMany().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(denonciation => denonciation.Suspect).WithMany().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(denonciation => denonciation.Reponse).WithOne().OnDelete(DeleteBehavior.NoAction);
    }
}