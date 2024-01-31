using JeBalance.API.Publique;
using JeBalance.Domain;
using JeBalance.Infrastructure;
using JeBalance.Infrastructure.SQLite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// For entity framework
services.AddDbContext<DatabaseContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("localdb")), ServiceLifetime.Scoped,
    ServiceLifetime.Transient);

services.AddApplication();
services.AddDomain();
services.AddInfrastructure();
services.AddControllers();

// Swagger
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();