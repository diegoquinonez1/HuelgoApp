using System.Security.Claims;
using Identity.Application;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace Identity.Api;

public static class IdentityEndpoints
{
    public static IEndpointRouteBuilder MapIdentityEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/auth");
        group.MapPost("/register", RegisterAsync);
        group.MapPost("/login", LoginAsync);
        group.MapPost("/logout", LogoutAsync).RequireAuthorization();
        endpoints.MapPost("/connect/token", TokenAsync);
        return endpoints;
    }

    private static async Task<IResult> RegisterAsync(RegisterUserRequest request, UserManager<ApplicationUser> userManager)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
        {
            return Results.ValidationProblem(new Dictionary<string, string[]> { ["registration"] = ["Complete all required fields."] });
        }

        var (result, user) = await IdentityModuleServiceCollectionExtensions.RegisterAsync(userManager, request, DateOnly.FromDateTime(DateTime.UtcNow));
        if (!result.Succeeded || user is null)
        {
            return Results.BadRequest(new { message = "The account could not be created. Check the supplied data or sign in." });
        }

        return Results.SignIn(IdentityModuleServiceCollectionExtensions.CreatePrincipal(user), authenticationScheme: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

    private static async Task<IResult> LoginAsync(LoginRequest request, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        var user = await userManager.FindByEmailAsync(request.Email.Trim());
        if (user is null)
        {
            return Results.Unauthorized();
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);
        if (!result.Succeeded)
        {
            return Results.Unauthorized();
        }

        return Results.SignIn(IdentityModuleServiceCollectionExtensions.CreatePrincipal(user), authenticationScheme: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

    private static async Task<IResult> LogoutAsync(ClaimsPrincipal principal, UserManager<ApplicationUser> userManager)
    {
        var user = await userManager.GetUserAsync(principal);
        if (user is not null)
        {
            await userManager.UpdateSecurityStampAsync(user);
        }

        return Results.NoContent();
    }

    private static async Task<IResult> TokenAsync(HttpContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        var form = await context.Request.ReadFormAsync();
        if (!string.Equals(form["grant_type"], "password", StringComparison.Ordinal))
        {
            return Results.BadRequest(new { error = "unsupported_grant_type" });
        }

        var user = await userManager.FindByEmailAsync(form["username"].ToString());
        if (user is null || !await signInManager.CanSignInAsync(user) || !await userManager.CheckPasswordAsync(user, form["password"].ToString()))
        {
            return Results.Forbid(authenticationSchemes: [OpenIddictServerAspNetCoreDefaults.AuthenticationScheme]);
        }

        return Results.SignIn(IdentityModuleServiceCollectionExtensions.CreatePrincipal(user), authenticationScheme: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }
}