using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CPIS_358_project.Models;
using CPIS_358_project.Data;

namespace CPIS_358_project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("CPIS_358_projectContextConnection") ?? throw new InvalidOperationException("Connection string 'CPIS_358_projectContextConnection' not found.");;

            builder.Services.AddDbContext<CPIS_358_projectContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<CPIS_358_projectContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout =
                TimeSpan.FromSeconds(300);
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });
            builder.Services.AddRazorPages(); 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages();
            app.Run();
        }
    }
}
