using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
//using Rms_Core_313.Data;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rms_Core_313.DataBaseContext.DataBaseContext;
using Rms_Core_313.BLL.BLL;
using Rms_Core_313.BLL.Interface;
using Rms_Core_313.Repository.Interface;
using Rms_Core_313.Repository.Repository;
using Stripe;
using Rms_Core_313.Models;

namespace Rms_Core_313
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ProjectDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ProjectDbContext>();

            //services.AddDbContextPool<ProjectDbContext>(options => options.UseSqlServer());
            
            
            services.AddScoped<DbContext, ProjectDbContext>();

            services.AddScoped<IMenuCreateManager, MenuCreateManager>();
            services.AddScoped<IMenuCreaterepository, MenuCreateRepository>();

            services.AddScoped<IMenuCreateManager, MenuCreateManager>();
            services.AddScoped<IMenuCreaterepository, MenuCreateRepository>();

            services.AddScoped<IOrderPlaceManager, OrderPlaceManager>();
            services.AddScoped<IOrderPlaceRepository, OrderPlaceRepository>();

            services.AddScoped<ITableBookingManager, TableBookingManager>();
            services.AddScoped<ITableBookingRepository, TableBookingCreateRepository>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            
            services.AddTransient<IMenuCreateManager, MenuCreateManager>();
            services.AddTransient<IMenuCreaterepository, MenuCreateRepository>();
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.Configure<StripeSetting>(Configuration.GetSection("Stripe"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.SetApiKey(Configuration.GetSection("stripe")["Secretkey"]);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
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
