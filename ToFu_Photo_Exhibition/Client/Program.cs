global using System.Net.Http.Json;
global using ToFu_Photo_Exhibition.Shared.Dto.Response;
global using ToFu_Photo_Exhibition.Client;
global using ToFu_Photo_Exhibition.Client.Services.CategoryService;
global using ToFu_Photo_Exhibition.Client.Services.RoundService;
global using ToFu_Photo_Exhibition.Client.Services.ManufacturerService;
global using ToFu_Photo_Exhibition.Client.Services.TeamService;
global using ToFu_Photo_Exhibition.Client.Services.CarService;
global using ToFu_Photo_Exhibition.Client.Services.PhotoService;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using ToFu_Photo_Exhibition.Client.Components.PhotoDialog;
global using Microsoft.AspNetCore.Components.Forms;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddHttpClient("ToFu_Photo_Exhibition.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IRoundService, RoundService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
await builder.Build().RunAsync();
