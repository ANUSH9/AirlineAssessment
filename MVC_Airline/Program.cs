using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Airline.Areas.Identity.Data;
using MVC_Airline.Data;
using AutoMapper;
using MVC_Airline.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MVC_AirlineContextConnection") ?? throw new InvalidOperationException("Connection string 'MVC_AirlineContextConnection' not found.");

builder.Services.AddDbContext<MVC_AirlineContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<MvcDbcontext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<MVC_AirlineUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<MVC_AirlineContext>();
builder.Services.AddIdentity<MVC_AirlineUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultUI().AddEntityFrameworkStores<MVC_AirlineContext>();
// Add services to the container.


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<MvcDbcontext>();
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
