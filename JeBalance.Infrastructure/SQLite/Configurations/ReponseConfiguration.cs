using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Infrastructure.SQLite.Configurations;

public class ReponseConfiguration : IEntityTypeConfiguration<ReponseSQLite>
{
    public void Configure(EntityTypeBuilder<ReponseSQLite> builder)
    {
        builder.ToTable("REPONSES")
            .HasKey(reponse => reponse.Id);

        // store enum as int
        builder.Property(reponse => reponse.TypeReponse).HasColumnType("int").IsRequired();
    }
}