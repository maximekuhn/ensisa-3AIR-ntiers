using JeBalance.API.Interne.Securisee;
using JeBalance.Domain;
using JeBalance.Infrastructure;
using JeBalance.Infrastructure.SQLite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// For entity framework
services.AddDbContext<DatabaseContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("localdb")), ServiceLifetime.Scoped, ServiceLifetime.Transient);

services.AddApplication();
services.AddDomain();
services.AddInfrastructure();
services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();