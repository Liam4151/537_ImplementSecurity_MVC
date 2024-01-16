using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SamsWarehouseWebApp.Models.Data;
using SamsWarehouseWebApp.Models.DBContext;
using SamsWarehouseWebApp.Repository;
using SamsWarehouseWebApp.Services;
using UploadEncryption.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ItemDBContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("JokesDBSQL")));
        builder.Services.AddSingleton<SanitiserService>();

        //builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
        //    .AddRoles<IdentityRole>()
        //    .AddRoleManager<RoleManager<IdentityRole>>()
        //.AddEntityFrameworkStores<DbContext>();



        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Home/Login";
                   options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                   options.SlidingExpiration = true;
                   options.AccessDeniedPath = "/Auth/AccessDenied";
               });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("UserPolicy", policy =>
            {
                policy.RequireClaim("StandardUser");
                policy.RequireClaim("Email");
            });
            options.AddPolicy("AdminPolicy", policy =>
            {
                policy.RequireRole("Admin");
                //policy.RequireClaim("IsOver18");
            });
        });

        builder.Services.AddSession();
        builder.Services.AddDistributedMemoryCache();

        builder.Services.AddScoped<FileUploaderService>();
        builder.Services.AddScoped<EncryptionService>();
        builder.Services.AddScoped<AuthRepository>();

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
        app.UseSession();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Login}/{id?}");

        app.Run();
    }
}

