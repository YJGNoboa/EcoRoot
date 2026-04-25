using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;

namespace EcoRoot.BlazorClient.Services
{
    /// <summary>
    /// HTTP interceptor that injects the JWT token into every request
    /// and redirects to login if the API returns 401.
    /// </summary>
    public class AuthMessageHandler : DelegatingHandler
    {
        private readonly AuthService _auth;
        private readonly NavigationManager _nav;

        public AuthMessageHandler(AuthService auth, NavigationManager nav)
        {
            _auth = auth;
            _nav  = nav;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _auth.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await _auth.LogoutAsync();
                _nav.NavigateTo("/login");
            }

            return response;
        }
    }
}
