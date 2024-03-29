using JeBalance.API.Securite.Shared.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.API.Securite.Shared;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext()
    {
    }

    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlite("Data Source=../JeBalance.Infrastructure/LocalDatabase.db");
    }
}