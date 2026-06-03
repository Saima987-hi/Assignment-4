using Application06.Components;
using Application06.Models;
using Application06.Services;

var builder = WebApplication.CreateBuilder(args);

// ─── Blazor & Razor Components ───────────────────────────────────────────────
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ─── Application Services (Dependency Injection) ─────────────────────────────

// Register NotificationConfig as Singleton so it is shared across the app
builder.Services.AddSingleton<NotificationConfig>(new NotificationConfig
{
    DefaultNumberOfNotifications = 5,
    NotificationStyle = "Compact"
});

// Register NotificationService (Scoped – gets the singleton config injected)
builder.Services.AddScoped<NotificationService>();

// ─── Build & Run ──────────────────────────────────────────────────────────────
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
