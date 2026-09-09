using Microsoft.EntityFrameworkCore;
using PortfolioSite.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioDb")));
/*
 Why this line matters: builder.Services.AddDbContext<...> registers your DbContext with ASP.NET Core's dependency injection container.
Think of that container like a hotel concierge — 
instead of every controller manually creating its own database connection (imagine every hotel guest having to personally go dig a key out of a locked cabinet), 
a controller just asks for a PortfolioDbContext in its constructor, 
and ASP.NET Core hands it a ready-to-use one automatically.
 */

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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PortfolioDbContext>();
    SeedData.Initialize(db);
}
/*
 Your PortfolioDbContext is normally handed out fresh per web request. 
 But at startup, there's no web request happening yet — so you manually ask the concierge for one "temporary key" (CreateScope()), 
 use it once to seed the database, and it's automatically returned/disposed when the using block ends. This prevents connections from leaking.
 */
app.Run();
