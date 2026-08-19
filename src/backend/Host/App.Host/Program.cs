using Identity.Api;
using Identity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Validation.AspNetCore;
using Sync.Api;
using Sync.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Postgres")
    ?? throw new InvalidOperationException("ConnectionStrings:Postgres must be configured.");

builder.Services.AddHealthChecks();
builder.Services.AddIdentityModule(connectionString);
builder.Services.AddSyncModule(connectionString);
builder.Services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment() && builder.Configuration.GetValue<bool>("Database:ApplyMigrations"))
{
    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<IdentityDbContext>().Database.MigrateAsync();
    await scope.ServiceProvider.GetRequiredService<SyncDbContext>().Database.MigrateAsync();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapHealthChecks("/health");
app.MapIdentityEndpoints();
app.MapSyncEndpoints();
app.Run();

public partial class Program;
