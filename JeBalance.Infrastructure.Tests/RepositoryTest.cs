using JeBalance.Architecture.SQLite;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.Tests;

public class RepositoryTest
{
    public DatabaseContext Context { get; private set; }

    public RepositoryTest()
    {
        var options = new DbContextOptionsBuilder<DbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        Context = new DatabaseContext(options);
    }
}