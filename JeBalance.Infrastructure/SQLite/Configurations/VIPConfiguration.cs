using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Infrastructure.SQLite.Configurations;

public class VIPConfiguration : IEntityTypeConfiguration<VIPsQLite>
{
    public void Configure(EntityTypeBuilder<VIPsQLite> builder)
    {
        builder.ToTable("VIPs")
            .HasKey(vip => vip.Id)
            ;
        
        //TODO
    }
}