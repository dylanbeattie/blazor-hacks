using Bongolis.Client;
using Bongolis.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())  app.UseWebAssemblyDebugging();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAntiforgery();

app.MapRazorPages();

 app.MapRazorComponents<App>()
 	.AddInteractiveServerRenderMode()
     .AddInteractiveWebAssemblyRenderMode()
     .AddAdditionalAssemblies(typeof(Bongolis.Client._Imports).Assembly)
     .AddAdditionalAssemblies(typeof(Bongolis.RazorClassLib._Imports).Assembly);
app.Run();
