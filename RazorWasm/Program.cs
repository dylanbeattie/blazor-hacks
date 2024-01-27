using RazorWasm.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseWebAssemblyDebugging();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
// app.MapBlazorHub();
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode();
app.Run();
