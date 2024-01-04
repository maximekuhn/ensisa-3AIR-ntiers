using JeBalance.Architecture.SQLite.Configurations;
using JeBalance.Architecture.SQLite.Model;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Architecture.SQLite;

public class DatabaseContext: DbContext
{
    public const string DEFAULT_SCHEMA = "app";
    
    public DbSet<DenonciationSQLite> Denonciations { get; set; }

    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DenonciationConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // TODO
            Console.WriteLine("TODO: implement OnConfiguring");
        }
    }
}