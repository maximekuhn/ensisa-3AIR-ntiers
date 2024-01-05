using JeBalance.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Architecture.SQLite.Configurations;

public class SuspectConfiguration: IEntityTypeConfiguration<Suspect>
{
    public void Configure(EntityTypeBuilder<Suspect> builder)
    {
        builder.ToTable("SUSPECTS", DatabaseContext.DEFAULT_SCHEMA)
            .HasKey(suspect => suspect.Id);
        
        // TODO
    }
}