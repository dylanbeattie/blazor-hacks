using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var sqliteConnection = new SqliteConnection("Data Source=:memory:");
sqliteConnection.Open();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite(sqliteConnection));
var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
	var db = scope.ServiceProvider.GetService<MyDbContext>()!;
	db.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();
app.MapGet("/", (MyDbContext db) => db.Artists.ToList());
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();

public static class ExtensionMethods {
	public static bool DoNothing(this WebApplicationBuilder builder) => true;
}

public class Artist {
	public Guid Id { get; set; }
	public string Name { get; set; } = String.Empty;
}

public class MyDbContext : DbContext {
	public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

	public DbSet<Artist> Artists { get; set; } = default!;
	protected override void OnModelCreating(ModelBuilder modelBuilder) 	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Artist>().HasData(
			new Artist { Id = Guid.NewGuid(), Name = "Artist A" },
			new Artist { Id = Guid.NewGuid(), Name = "Artist B" },
			new Artist { Id = Guid.NewGuid(), Name = "Artist C" }
		);
	}
}