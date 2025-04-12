using OnlineShopBlazor.Components;
using Microsoft.EntityFrameworkCore;
using OnlineShopBlazor.Models.Db;
using FluentValidation;
using OnlineShopBlazor.Models.db;
using Microsoft.AspNetCore.Authentication.Cookies;
using OnlineShopBlazor.Models.Validations;
using Microsoft.AspNetCore.Components.Authorization;

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

builder.Services.AddScoped<AuthenticationStateProvider, AuthService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddAuthorizationCore();

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

app.Run();
