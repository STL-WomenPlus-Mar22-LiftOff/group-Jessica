using HouseholdManager.Areas.Identity.Data;
using HouseholdManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddIdentity<Member, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();
/*

builder.Services.AddHttpContextAccessor();
// Identity services
builder.Services.TryAddScoped<IUserValidator<Member>, UserValidator<Member>>();
builder.Services.TryAddScoped<IPasswordValidator<Member>, PasswordValidator<Member>>();
builder.Services.TryAddScoped<IPasswordHasher<Member>, PasswordHasher<Member>>();
builder.Services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
builder.Services.TryAddScoped<IRoleValidator<IdentityRole>, RoleValidator<IdentityRole>>();
// No interface for the error describer so we can add errors without rev'ing the interface
builder.Services.TryAddScoped<IdentityErrorDescriber>();
builder.Services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<Member>>();
builder.Services.TryAddScoped<ITwoFactorSecurityStampValidator, TwoFactorSecurityStampValidator<Member>>();
builder.Services.TryAddScoped<IUserClaimsPrincipalFactory<Member>, UserClaimsPrincipalFactory<Member, IdentityRole>>();
builder.Services.TryAddScoped<UserManager<Member>>();
builder.Services.TryAddScoped<SignInManager<Member>>();
builder.Services.TryAddScoped<RoleManager<IdentityRole>>();
*/

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2VVhkQlFadVdJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRjWH5ZcHBRRmRbVE0=");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
