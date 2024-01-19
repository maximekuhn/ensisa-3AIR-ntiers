using JeBalance.Architecture.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Architecture.SQLite.Configurations;

public class SuspectConfiguration : IEntityTypeConfiguration<SuspectSQLite>
{
    public void Configure(EntityTypeBuilder<SuspectSQLite> builder)
    {
        builder.ToTable("SUSPECTS", DatabaseContext.DEFAULT_SCHEMA)
            .HasKey(suspect => suspect.Id);

        // TODO
    }
}