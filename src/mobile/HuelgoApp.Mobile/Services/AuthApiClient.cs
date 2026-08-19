using System.Net.Http.Json;

namespace HuelgoApp.Mobile.Services;

public sealed class AuthApiClient(OfflineStore offlineStore)
{
    private static readonly HttpClient HttpClient = new() { BaseAddress = new Uri("https://localhost:7291/") };

    public async Task RegisterAsync(string? firstName, string? lastName, DateOnly birthDate, string? email, string? password, string? confirmPassword)
    {
        var response = await HttpClient.PostAsJsonAsync("api/auth/register", new { firstName, lastName, birthDate, email, password, confirmPassword });
        response.EnsureSuccessStatusCode();
        await LoginAsync(email, password);
    }

    public async Task LoginAsync(string? email, string? password)
    {
        var response = await HttpClient.PostAsync("connect/token", new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["grant_type"] = "password",
            ["username"] = email ?? string.Empty,
            ["password"] = password ?? string.Empty,
            ["scope"] = "offline_access"
        }));
        await PersistTokensAsync(response);
    }

    public async Task LogoutAsync()
    {
        var accessToken = await SecureStorage.Default.GetAsync("huelgo.access_token");
        if (!string.IsNullOrEmpty(accessToken))
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, "api/auth/logout");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            await HttpClient.SendAsync(request);
        }
        SecureStorage.Default.Remove("huelgo.access_token");
        SecureStorage.Default.Remove("huelgo.refresh_token");
    }

    public async Task<bool> HasSessionAsync() => !string.IsNullOrEmpty(await SecureStorage.Default.GetAsync("huelgo.access_token"));

    public async Task RefreshSessionAsync()
    {
        var refreshToken = await SecureStorage.Default.GetAsync("huelgo.refresh_token");
        if (string.IsNullOrEmpty(refreshToken))
        {
            return;
        }

        var response = await HttpClient.PostAsync("connect/token", new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["grant_type"] = "refresh_token",
            ["refresh_token"] = refreshToken
        }));
        await PersistTokensAsync(response);
    }

    public async Task SyncPendingChangesAsync()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return;
        }

        var changes = await offlineStore.GetPendingAsync();
        if (changes.Count == 0)
        {
            return;
        }

        var accessToken = await SecureStorage.Default.GetAsync("huelgo.access_token");
        if (string.IsNullOrEmpty(accessToken))
        {
            return;
        }

        using var request = new HttpRequestMessage(HttpMethod.Post, "api/sync/push")
        {
            Content = JsonContent.Create(new
            {
                changes = changes.Select(change => new
                {
                    entityType = change.EntityType,
                    entityId = change.EntityId,
                    payload = change.Payload,
                    updatedAt = change.UpdatedAt,
                    deletedAt = (DateTimeOffset?)null
                })
            })
        };
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        var response = await HttpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        await offlineStore.RemoveAsync(changes);
    }

    private async Task PersistTokensAsync(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var token = await response.Content.ReadFromJsonAsync<TokenResponse>() ?? throw new InvalidOperationException("The server did not return a token.");
        await SecureStorage.Default.SetAsync("huelgo.access_token", token.AccessToken);
        await SecureStorage.Default.SetAsync("huelgo.refresh_token", token.RefreshToken ?? string.Empty);
        await offlineStore.InitializeAsync();
    }

    private sealed record TokenResponse(string AccessToken, string? RefreshToken);
}