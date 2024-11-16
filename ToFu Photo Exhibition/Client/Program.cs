global using ToFu_Photo_Exhibition.Shared;
global using ToFu_Photo_Exhibition.Shared.Models;
global using System.Net.Http.Json;
global using ToFu_Photo_Exhibition.Client.Services.CategoryService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ToFu_Photo_Exhibition.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddHttpClient("ToFu_Photo_Exhibition.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICategoryService, CategoryService>();
await builder.Build().RunAsync();
