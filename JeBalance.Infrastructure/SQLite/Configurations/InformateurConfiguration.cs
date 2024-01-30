using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Infrastructure.SQLite.Configurations;

public class InformateurConfiguration : IEntityTypeConfiguration<InformateurSQLite>
{
    public void Configure(EntityTypeBuilder<InformateurSQLite> builder)
    {
        builder.ToTable("INFORMATEURS").HasKey(informateur => informateur.Id);

        builder.Property(informateur => informateur.Adresse).IsRequired();
        builder.Property(informateur => informateur.Nom).IsRequired().HasMaxLength(Nom.MAX_LENGTH);
        builder.Property(informateur => informateur.Prenom).IsRequired().HasMaxLength(Nom.MAX_LENGTH);
        builder.Property(informateur => informateur.EstCalomniateur).IsRequired();
    }
}