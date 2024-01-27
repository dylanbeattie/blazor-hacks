using System.Text.Json;
using Microsoft.Data.Sqlite;
using Rockaway.WebApp.Data;
using Rockaway.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages(options => options.Conventions.AuthorizeAreaFolder("admin", "/"));
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IClock>(SystemClock.Instance);
builder.Services.Configure<JsonOptions>(options => {
	// NodaTime.Serialization.SystemTextJson.Extensions.ConfigureForNodaTime(options, DateTimeZoneProviders.Tzdb)
	// options.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
});


var sqliteConnection = new SqliteConnection("Data Source=:memory:");
sqliteConnection.Open();
builder.Services.AddDbContext<RockawayDbContext>(options => options.UseSqlite(sqliteConnection));

// builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
	using var db = scope.ServiceProvider.GetService<RockawayDbContext>()!;
	db.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAntiforgery();
app.MapRazorPages();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
