using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using WebRestaurant.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebRestaurant
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

          
            services.AddIdentity<WebUser, WebRole>(options =>
             {
                 options.User.RequireUniqueEmail = true;

             }).AddEntityFrameworkStores<IdentityContext>();

            services.AddDbContext<IdentityContext>(cfg =>
           {
               cfg.UseSqlServer(Configuration.GetConnectionString("retdb"));
           });


            if (Configuration["OtherRepository"] == "true")
            {
                //services.AddScoped<IRepository, NonEfRepository>();
            }
            else
            {
                // "if a class asks for an IRepository, give it a Repository"
                services.AddScoped<IDL, DL>();
            }


            services.AddDbContext<RetP0Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("retdb"));
         
            });

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
