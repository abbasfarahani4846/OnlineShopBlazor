using OnlineShopBlazor.Components;
using Microsoft.EntityFrameworkCore;
using OnlineShopBlazor.Models.Db;
using FluentValidation;
using OnlineShopBlazor.Models.db;
using Microsoft.AspNetCore.Authentication.Cookies;
using OnlineShopBlazor.Models.Validations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<OnlineShopOrginalContext>();

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddBlazorBootstrap();

// Register FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CommentValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RecoveryPasswordValidator>();

// --- Authentication Configuration START ---
builder.Services.AddAuthentication("MyCookieAuth") // Use a specific scheme name
    .AddCookie("MyCookieAuth", options => // Must match scheme name above
    {
        options.Cookie.Name = "OnlineShop.Auth";
        options.LoginPath = "/login"; // Page users are sent to when they need to log in
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie expiration
    });

builder.Services.AddAuthorization();
builder.Services.AddRazorPages();

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

app.UseAuthentication();     // اضافه کن
app.UseAuthorization();      // اضافه کن


app.MapRazorPages(); // حتماً باید باشه!

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
