using JeBalance.Infrastructure.SQLite;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.Tests;

public class RepositoryTest
{
    public RepositoryTest()
    {
        var options = new DbContextOptionsBuilder<DbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        Context = new DatabaseContext(options);
    }

    public DatabaseContext Context { get; private set; }
}