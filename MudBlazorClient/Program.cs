using MudBlazorClient;
using MudBlazor.Services;
using MudBlazorClient.Services;
using MudBlazorClient.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44351/") });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
