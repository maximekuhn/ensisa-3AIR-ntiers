using JeBalance.Architecture.SQLite.Configurations;
using JeBalance.Architecture.SQLite.Model;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Architecture.SQLite;

public class DatabaseContext : DbContext
{
    public const string DEFAULT_SCHEMA = "app";

    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<DenonciationSQLite> Denonciations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DenonciationConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite("Data Source=LocalDatabase.db");
    }
}