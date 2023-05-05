using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SemesterProjekt3Web.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SemesterProjekt3WebContextConnection") ?? throw new InvalidOperationException("Connection string 'SemesterProjekt3WebContextConnection' not found.");

builder.Services.AddDbContext<SemesterProjekt3WebContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SemesterProjekt3WebContext>();

// Add services to the container.
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

/*app.MapAreaControllerRoute(
    name: "Identity",
    areaName: "Identity",
    pattern: "/Areas/Identity");*/


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Movies}/{id?}");
app.MapControllerRoute(
    name: "showings", pattern: "Movies/{id}/Showings", defaults: new { controller = "Home", action = "Showings" });
app.Run();
