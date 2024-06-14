using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TestProject.Application.Interfaces.Context;
using TestProject.Domain.Entity;
using TestProject.Persistance.Context;
using TestProject.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//Dbcontext
builder.Services.AddScoped<IDatabaseContext,DatabaseContext>();

#region Add Authentication

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders()
    .AddRoles<Role>()
    .AddErrorDescriber<PersianIdentityErrorDescriber>();

builder.Services.Configure<IdentityOptions>(option =>
{
    option.User.RequireUniqueEmail = true;

    option.Password.RequireDigit = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
    option.Password.RequiredLength = 6;
    option.Password.RequiredUniqueChars = 0;

    option.SignIn.RequireConfirmedAccount = true;
    option.SignIn.RequireConfirmedEmail = true;
    option.SignIn.RequireConfirmedPhoneNumber = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(12);
    options.LoginPath = "/Auth/SignIn";
    options.LogoutPath = "/Auth/SignOut";
    options.AccessDeniedPath = "/AccessDenied";
    options.SlidingExpiration = true;
});





builder.Services.AddScoped<IClaimsTransformation, AddRoleToClaimOnSignIn>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=List}");


app.Run();
