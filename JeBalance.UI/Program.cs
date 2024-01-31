using Blazored.Modal;
using JeBalance.UI.Authentification;
using JeBalance.UI.Data.Services.InterneAPI;
using JeBalance.UI.Data.Services.PubliqueAPI;
using JeBalance.UI.Data.Services.SecreteAPI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using DenonciationServices = JeBalance.UI.Data.Services.PubliqueAPI.DenonciationServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddBlazoredModal();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<LoginServices>();
builder.Services.AddSingleton<SignupServices>();
builder.Services.AddScoped<DenonciationServices>();
builder.Services.AddScoped<DenonciationGetServices>();
builder.Services.AddScoped<VIPServices>();
builder.Services.AddScoped<VIPGetServices>();
builder.Services.AddScoped<JeBalance.UI.Data.Services.InterneAPI.DenonciationServices>();
builder.Services.AddScoped<ReponseServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();