using JeBalance.Architecture.SQLite.Model;
using JeBalance.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JeBalance.Architecture.SQLite.Configurations;

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