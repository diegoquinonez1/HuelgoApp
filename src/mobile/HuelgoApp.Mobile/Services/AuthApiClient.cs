using System.Net.Http.Json;

namespace HuelgoApp.Mobile.Services;

public sealed class AuthApiClient(OfflineStore offlineStore)
{
    private static readonly HttpClient HttpClient = new() { BaseAddress = new Uri("https://localhost:7291/") };

    public async Task RegisterAsync(string? firstName, string? lastName, DateOnly birthDate, string? email, string? password, string? confirmPassword)
    {
        var response = await HttpClient.PostAsJsonAsync("api/auth/register", new { firstName, lastName, birthDate, email, password, confirmPassword });
        await PersistTokensAsync(response);
    }

    public async Task LoginAsync(string? email, string? password)
    {
        var response = await HttpClient.PostAsJsonAsync("api/auth/login", new { email, password });
        await PersistTokensAsync(response);
    }

    public async Task LogoutAsync()
    {
        SecureStorage.Default.Remove("huelgo.access_token");
        SecureStorage.Default.Remove("huelgo.refresh_token");
        await Task.CompletedTask;
    }

    public async Task<bool> HasSessionAsync() => !string.IsNullOrEmpty(await SecureStorage.Default.GetAsync("huelgo.access_token"));

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