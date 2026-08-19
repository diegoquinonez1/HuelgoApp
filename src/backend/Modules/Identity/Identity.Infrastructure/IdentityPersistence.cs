using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using Identity.Application;
using Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;
using OpenIddict.EntityFrameworkCore.Models;

namespace Identity.Infrastructure;

public sealed class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}

public sealed class IdentityDbContext(DbContextOptions<IdentityDbContext> options)
    : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<ApplicationUser, IdentityRole, string>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("identity");
        base.OnModelCreating(builder);
        builder.UseOpenIddict();
        builder.Entity<ApplicationUser>().Property(user => user.FirstName).HasMaxLength(100);
        builder.Entity<ApplicationUser>().Property(user => user.LastName).HasMaxLength(100);
    }
}

public static class IdentityModuleServiceCollectionExtensions
{
    public static IServiceCollection AddIdentityModule(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<IdentityDbContext>(options => options.UseNpgsql(connectionString));
        services
            .AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddOpenIddict()
            .AddCore(options => options.UseEntityFrameworkCore().UseDbContext<IdentityDbContext>())
            .AddServer(options =>
            {
                options.SetTokenEndpointUris("/connect/token");
                options.AllowPasswordFlow();
                options.AllowRefreshTokenFlow();
                options.AcceptAnonymousClients();
                options.RegisterScopes(OpenIddictConstants.Scopes.OfflineAccess);
                options.SetIssuer(new Uri("https://localhost:7102/"));
                options.SetAccessTokenLifetime(TimeSpan.FromMinutes(15));
                options.SetRefreshTokenLifetime(TimeSpan.FromDays(30));
                options.DisableAccessTokenEncryption();
                options.AddDevelopmentEncryptionCertificate();
                options.AddDevelopmentSigningCertificate();
                options.UseAspNetCore().EnableTokenEndpointPassthrough().DisableTransportSecurityRequirement();
            })
            .AddValidation(options =>
            {
                options.UseLocalServer();
                options.EnableTokenEntryValidation();
                options.UseAspNetCore();
            });

        return services;
    }

    public static ClaimsPrincipal CreatePrincipal(ApplicationUser user)
    {
        var identity = new ClaimsIdentity("Bearer");
        foreach (var claim in new[]
        {
            new Claim(OpenIddictConstants.Claims.Subject, user.Id),
            new Claim(OpenIddictConstants.Claims.Email, user.Email ?? string.Empty),
            new Claim(OpenIddictConstants.Claims.Name, user.UserName ?? string.Empty),
            new Claim("security_stamp", user.SecurityStamp ?? string.Empty)
        })
        {
            claim.SetDestinations(OpenIddictConstants.Destinations.AccessToken);
            identity.AddClaim(claim);
        }
        var principal = new ClaimsPrincipal(identity);
        principal.SetScopes(OpenIddictConstants.Scopes.OfflineAccess);
        return principal;
    }

    public static async Task<(IdentityResult Result, ApplicationUser? User)> RegisterAsync(
        UserManager<ApplicationUser> userManager,
        RegisterUserRequest request,
        DateOnly today)
    {
        if (!RegistrationRules.IsAtLeastThirteen(request.BirthDate, today))
        {
            return (IdentityResult.Failed(new IdentityError { Description = "You must be at least 13 years old." }), null);
        }

        if (!string.Equals(request.Password, request.ConfirmPassword, StringComparison.Ordinal))
        {
            return (IdentityResult.Failed(new IdentityError { Description = "Passwords do not match." }), null);
        }

        if (!new EmailAddressAttribute().IsValid(request.Email))
        {
            return (IdentityResult.Failed(new IdentityError { Description = "Email address is invalid." }), null);
        }

        var user = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = request.Email.Trim(),
            Email = request.Email.Trim(),
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            BirthDate = request.BirthDate
        };
        return (await userManager.CreateAsync(user, request.Password), user);
    }
}