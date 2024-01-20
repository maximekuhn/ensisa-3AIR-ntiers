using JeBalance.Architecture.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Architecture.SQLite.Configurations;

public class InformateurConfiguration : IEntityTypeConfiguration<InformateurSQLite>
{
    public void Configure(EntityTypeBuilder<InformateurSQLite> builder)
    {
        builder.ToTable("INFORMATEURS").HasKey(informateur => informateur.Id);
        // TODO
    }
}