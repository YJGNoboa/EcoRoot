using EcoRoot.BlazorClient.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<EcoRoot.BlazorClient.App>("#app");
builder.RootComponents.Add<Microsoft.AspNetCore.Components.Web.HeadOutlet>("head::after");

var apiBase = new Uri("https://localhost:7264/");

builder.Services.AddHttpClient("EcoRootPublic", c => c.BaseAddress = apiBase);

builder.Services.AddScoped<AuthService>();

builder.Services.AddTransient<AuthMessageHandler>();

builder.Services.AddHttpClient("EcoRootAPI", c => c.BaseAddress = apiBase)
    .AddHttpMessageHandler<AuthMessageHandler>();

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("EcoRootAPI"));

await builder.Build().RunAsync();
