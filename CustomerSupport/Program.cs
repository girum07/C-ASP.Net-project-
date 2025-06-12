using CustomerSupportUI.Components;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;  
using Microsoft.AspNetCore.Identity;
using Domain.Entity;
using Domain.Interface;
using MudBlazor.Services;
using Infrastructure.Service;






var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMudServices();
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication()
    .AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/loginpage"; // Adjust the login path as needed
    options.AccessDeniedPath = "/access-denied"; // Adjust the access denied path as needed 
    options.LogoutPath = "/logout"; // Adjust the logout path as needed
});

builder.Services.AddDbContext<AppDBcontext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDBcontext>()
  .AddSignInManager();
builder.Services.AddScoped<IAccountService, AccountService>(); // Register your account service 
 // Register your unit of work service
builder.Services.AddScoped<ICriteriaService, CriteriaService>(); // Register your criteria service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
