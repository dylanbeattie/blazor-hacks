using RazorComponentProblems.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
