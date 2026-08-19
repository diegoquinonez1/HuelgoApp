using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Sync.Application;
using Sync.Infrastructure;

namespace Sync.Api;

public static class SyncEndpoints
{
    public static IEndpointRouteBuilder MapSyncEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/sync").RequireAuthorization();
        group.MapPost("/push", PushAsync);
        group.MapGet("/pull", PullAsync);
        return endpoints;
    }

    private static async Task<IResult> PushAsync(PushSyncRequest request, ClaimsPrincipal principal, SyncService syncService, CancellationToken cancellationToken)
    {
        var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? principal.FindFirstValue("sub");
        if (string.IsNullOrEmpty(userId)) return Results.Unauthorized();
        await syncService.PushAsync(userId, request.Changes, cancellationToken);
        return Results.NoContent();
    }

    private static async Task<IResult> PullAsync(DateTimeOffset? since, ClaimsPrincipal principal, SyncService syncService, CancellationToken cancellationToken)
    {
        var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? principal.FindFirstValue("sub");
        return string.IsNullOrEmpty(userId) ? Results.Unauthorized() : Results.Ok(await syncService.PullAsync(userId, since, cancellationToken));
    }
}