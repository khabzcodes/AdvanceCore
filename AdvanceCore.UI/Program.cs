global using Microsoft.AspNetCore.Components.Authorization;
global using System.Security.Claims;
using AdvanceCore.UI;
using AdvanceCore.UI.Helpers;
using AdvanceCore.UI.Services;
using AdvanceCore.UI.Services.Implementations;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:7061") });

//builder.Services.AddScoped(sp =>
//{
//    var client = new HttpClient
//    {
//        BaseAddress = new Uri("https://localhost:7061")
//    };
//    client.DefaultRequestHeaders.Add("Content-Type", "application/json");
//    return client;
//});
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAntDesign();

await builder.Build().RunAsync();
