using BlazorSignalRApp.Components;
using BlazorSignalRApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.MapHub<ChatHub>("/chathub");

app.Run();
