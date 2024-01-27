using AlbumWeb.Components;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();
var app = builder.Build();
if (app.Environment.IsDevelopment()) app.UseWebAssemblyDebugging();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapRazorComponents<App>()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(AlbumRating._Imports).Assembly);
app.Run();
