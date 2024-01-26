using System.Text;
using JeBalance.API.Secrete.Securisee;
using JeBalance.API.Securite.Shared;
using JeBalance.Domain;
using JeBalance.Infrastructure;
using JeBalance.Infrastructure.SQLite;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// For entity framework
services.AddDbContext<DatabaseContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("localdb")), ServiceLifetime.Scoped,
    ServiceLifetime.Transient);

// Swagger
services.AddEndpointsApiExplorer();

// Configure security
SecurityConfigurer.ConfigureSecurity(services, builder);

services.AddApplication();
services.AddDomain();
services.AddInfrastructure();
services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();