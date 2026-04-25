using EcoRoot.BlazorClient.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<EcoRoot.BlazorClient.App>("#app");
builder.RootComponents.Add<Microsoft.AspNetCore.Components.Web.HeadOutlet>("head::after");

var apiBase = new Uri("https://localhost:7264/");

// Public client (no auth) — used by AuthService for login/register
builder.Services.AddHttpClient("EcoRootPublic", c => c.BaseAddress = apiBase);

// AuthService (uses the public client, NOT the authenticated one)
builder.Services.AddScoped<AuthService>();

// Handler that injects the JWT token into every request
builder.Services.AddTransient<AuthMessageHandler>();

// Authenticated client — used by all pages
builder.Services.AddHttpClient("EcoRootAPI", c => c.BaseAddress = apiBase)
    .AddHttpMessageHandler<AuthMessageHandler>();

// Default HttpClient injected via @inject in components
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("EcoRootAPI"));

await builder.Build().RunAsync();
