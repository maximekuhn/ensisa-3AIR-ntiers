using JeBalance.Domain.ValueObjects;
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

        builder.Property(vip => vip.Adresse).IsRequired();
        builder.Property(vip => vip.Nom).IsRequired().HasMaxLength(Nom.MAX_LENGTH);
        builder.Property(vip => vip.Prenom).IsRequired().HasMaxLength(Nom.MAX_LENGTH);
    }
}