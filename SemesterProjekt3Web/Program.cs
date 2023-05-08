var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=movies}/{id?}");
app.MapControllerRoute(
    name: "showings", pattern: "Movies/{id}/Showings", defaults: new { controller = "Home", action = "Showings" });
app.MapControllerRoute(
    name: "seats", pattern: "Bookings/Showings/{id}/Seats", defaults: new { controller = "Booking", action = "Seats" });
app.Run();
