using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Services;
using Microsoft.EntityFrameworkCore;
using AssuncaoDistribution.Areas.Identity.Data;
using System;
using Microsoft.AspNetCore.Identity;
using Pomelo.EntityFrameworkCore.MySql;

namespace AssuncaoDistribution
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile(path: $"appsettings.{hostEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

       
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRazorPages();
            services.AddControllersWithViews();

            services.AddScoped<SeedingService>();
            services.AddScoped<ProductServices>();
            services.AddScoped<ProviderServices>();
            services.AddScoped<ClientServices>();
            services.AddDbContext<AssuncaoDistributionContext>(options => options.UseMySql(Configuration["ConnectionStrings:AssuncaoDistributionContext"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:AssuncaoDistributionContext"])));


            services.AddDbContext<IdentityContext>(options =>
                    options.UseMySql(
                        Configuration["ConnectionStrings:IdentityContextConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:IdentityContextConnection"])));



            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<IdentityContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seedingService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }
            else
            {
                seedingService.Seed();
                app.UseExceptionHandler("/error/500");
                app.UseStatusCodePagesWithRedirects("/error/{0}");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
