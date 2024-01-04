using JeBalance.Architecture.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Architecture.SQLite.Configurations;

public class DenonciationConfiguration : IEntityTypeConfiguration<DenonciationSQLite>
{
    public void Configure(EntityTypeBuilder<DenonciationSQLite> builder)
    {
        // TODO: complete
        builder.ToTable("DENONCIATIONS", DatabaseContext.DEFAULT_SCHEMA)
            .HasKey(denonciation => denonciation.Id);

        // TODO: get max length from JeBalance.Domain
        builder.Property(denonciation => denonciation.NomInformateur).IsRequired().HasMaxLength(150);
    }
}