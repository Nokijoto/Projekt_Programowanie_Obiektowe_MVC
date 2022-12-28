using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Context;
using Projekt_MVC.Models;
using Projekt_MVC.Services.Car;
using Projekt_MVC.Services.SalonList;
using Projekt_MVC.Services.TestDrive;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MainContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CarContext")));


builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ITestDriveService, TestDriveService>();
builder.Services.AddScoped<ISalonListService, SalonListService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(
//    name: "carlist",
//    pattern: "{controller=CarList}/{action=NewCar}/");

app.Run();
