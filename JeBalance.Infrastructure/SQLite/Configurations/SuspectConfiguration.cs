using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Infrastructure.SQLite.Configurations;

public class SuspectConfiguration : IEntityTypeConfiguration<SuspectSQLite>
{
    public void Configure(EntityTypeBuilder<SuspectSQLite> builder)
    {
        builder.ToTable("SUSPECTS")
            .HasKey(suspect => suspect.Id);

        // TODO
    }
}