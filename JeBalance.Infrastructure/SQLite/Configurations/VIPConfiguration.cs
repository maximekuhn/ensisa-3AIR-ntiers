using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Infrastructure.SQLite.Configurations;

public class VIPConfiguration : IEntityTypeConfiguration<VIPSQLite>
{
    public void Configure(EntityTypeBuilder<VIPSQLite> builder)
    {
        builder.ToTable("VIP")
            .HasKey(vip => vip.Id)
            ;
        
        //TODO
    }
}