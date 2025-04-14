using OnlineShopBlazor.Components;
using Microsoft.EntityFrameworkCore;
using OnlineShopBlazor.Models.Db;
using FluentValidation;
using OnlineShopBlazor.Models.db;
using Microsoft.AspNetCore.Authentication.Cookies;
using OnlineShopBlazor.Models.Validations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication;
using BlazorLoginExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<OnlineShopContext>();

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddBlazorBootstrap();

// Register FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CommentValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();


// --- Authentication Configuration START ---
builder.Services.AddAuthentication("MyCookieAuth") // Use a specific scheme name
    .AddCookie("MyCookieAuth", options => // Must match scheme name above
    {
        options.Cookie.Name = "OnlineShop.Auth";
        options.LoginPath = "/login"; // Page users are sent to when they need to log in
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie expiration
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<LoginService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// --- Logout Endpoint START ---
// Map a specific endpoint for handling the logout POST request
app.MapPost("/logout", async (HttpContext ctx) =>
{
    await ctx.SignOutAsync("MyCookieAuth"); // Use the correct scheme name
    return Results.Redirect("/"); // Redirect to home page after logout
}).RequireAuthorization(); // Only authenticated users can logout
// --- Logout Endpoint END ---


app.Run();
