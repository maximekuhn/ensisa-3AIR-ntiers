using JeBalance.Architecture.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Architecture.SQLite.Configurations;

public class DenonciationConfiguration : IEntityTypeConfiguration<DenonciationSQLite>
{
    public void Configure(EntityTypeBuilder<DenonciationSQLite> builder)
    {
        builder.ToTable("DENONCIATIONS", DatabaseContext.DEFAULT_SCHEMA)
            .HasKey(denonciation => denonciation.Id);

        // store enum as int
        builder.Property(denonciation => denonciation.TypeDelit).HasColumnType("int").IsRequired();
        builder.Property(denonciation => denonciation.Statut).HasColumnType("int").IsRequired();

        // builder.HasOne(denonciation => denonciation.Informateur);

        // TODO: use object values constraints
    }
}