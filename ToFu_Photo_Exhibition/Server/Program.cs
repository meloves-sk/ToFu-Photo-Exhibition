global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
global using ToFu_Photo_Exhibition.Server.Models;
global using ToFu_Photo_Exhibition.Shared.Dto.Request;
global using ToFu_Photo_Exhibition.Shared.Dto.Response;
global using ToFu_Photo_Exhibition.Server.Services.CarService;
global using ToFu_Photo_Exhibition.Server.Services.CategoryService;
global using ToFu_Photo_Exhibition.Server.Services.ManufacturerService;
global using ToFu_Photo_Exhibition.Server.Services.PhotoService;
global using ToFu_Photo_Exhibition.Server.Services.RoundService;
global using ToFu_Photo_Exhibition.Server.Services.TeamInformationService;
global using ToFu_Photo_Exhibition.Server.Services.TeamService;
global using SixLabors.ImageSharp;
global using SixLabors.ImageSharp.Formats.Png;
global using SixLabors.ImageSharp.Processing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DB>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamInformationService, TeamInformationService>();
builder.Services.AddScoped<IRoundService, RoundService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();