using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using ReadyPlayerOne.Migrations;
using ReadyPlayerOne.Models;

var builder = WebApplication.CreateBuilder(args);

// Add session services
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DI
builder.Services.AddDbContext<PlayerContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "PlayerContext")));


//Adding Middleware for Authentication. Password of 6 characters
builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequiredLength = 6; options.Password.RequireNonAlphanumeric = false; options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<PlayerContext>().AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Add Session
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

//Add area for admin
app.MapAreaControllerRoute(
    name: "admin", 
    areaName: "Admin", 
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Routing for sorting by Alignment

app.MapControllerRoute(
    name: "custom",
    pattern: "{controller}/{action}");

app.MapControllerRoute(
    name: "custom",
    pattern: "{controller}/{action}/align-{activeAlign}");


app.Run();

