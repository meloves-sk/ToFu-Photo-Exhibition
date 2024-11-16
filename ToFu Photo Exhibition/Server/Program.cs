global using ToFu_Photo_Exhibition.Shared;
global using Microsoft.EntityFrameworkCore;
global using ToFu_Photo_Exhibition.Server.Services.CategoryService;
global using ToFu_Photo_Exhibition.Server.Services.ManufacturerService;
global using ToFu_Photo_Exhibition.Server.Services.TeamService;
global using ToFu_Photo_Exhibition.Server.Services.RoundService;
global using ToFu_Photo_Exhibition.Server.Services.CarService;
global using ToFu_Photo_Exhibition.Shared.Models;
global using Data;
global using Microsoft.AspNetCore.Mvc;
using Data;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DB>(a => a.UseMySql(builder.Configuration.GetConnectionString("DB"), new MariaDbServerVersion(new Version(10, 11, 6))));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IRoundService, RoundService>();
builder.Services.AddScoped<ICarService, CarService>();
var app = builder.Build();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseSwagger();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
