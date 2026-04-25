using EcoRoot.BlazorClient.Models;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text.Json;

namespace EcoRoot.BlazorClient.Services
{
    public class AuthService
    {
        // Public HTTP client (no auth handler) — avoids circular dependency
        private readonly IHttpClientFactory _httpFactory;
        private readonly IJSRuntime _js;
        private const string TokenKey = "ecoroot_token";
        private const string UserKey  = "ecoroot_user";

        public AuthService(IHttpClientFactory httpFactory, IJSRuntime js)
        {
            _httpFactory = httpFactory;
            _js          = js;
        }

        private HttpClient Http => _httpFactory.CreateClient("EcoRootPublic");

        public async Task<(bool Ok, string? Error)> LoginAsync(string username, string password)
        {
            try
            {
                var response = await Http.PostAsJsonAsync("api/auth/login",
                    new LoginRequest { Username = username, Password = password });

                if (!response.IsSuccessStatusCode)
                    return (false, "Invalid username or password.");

                var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
                if (result?.Token is null)
                    return (false, "Unexpected server response.");

                await _js.InvokeVoidAsync("localStorage.setItem", TokenKey, result.Token);
                await _js.InvokeVoidAsync("localStorage.setItem", UserKey, result.Username);
                return (true, null);
            }
            catch
            {
                return (false, "Could not connect to the server.");
            }
        }

        public async Task LogoutAsync()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
            await _js.InvokeVoidAsync("localStorage.removeItem", UserKey);
        }

        public async Task<string?> GetTokenAsync() =>
            await _js.InvokeAsync<string?>("localStorage.getItem", TokenKey);

        public async Task<string?> GetUsernameAsync() =>
            await _js.InvokeAsync<string?>("localStorage.getItem", UserKey);

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token)) return false;

            try
            {
                // Decode the JWT payload to verify expiration
                var payload = token.Split('.')[1];
                var padded  = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');
                var json    = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                                  Convert.FromBase64String(padded));

                if (json?.TryGetValue("exp", out var exp) == true)
                {
                    var expTime = DateTimeOffset.FromUnixTimeSeconds(exp.GetInt64());
                    return expTime > DateTimeOffset.UtcNow;
                }
            }
            catch { }

            return false;
        }
    }
}
