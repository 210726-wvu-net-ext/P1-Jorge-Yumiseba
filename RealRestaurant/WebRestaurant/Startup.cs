using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
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
using Microsoft.AspNetCore.Identity;

namespace WebRestaurant
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDL, DL>();


            services.AddDbContext<RetP0Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("retdb"));

            });

            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
              {
               options.LoginPath = "/login";
                  options.AccessDeniedPath = "/denied";
           

                  options.Events = new CookieAuthenticationEvents()
                  {
                      OnSigningIn = async context =>
                      {
                          var principal = context.Principal;
                          if(principal.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
                          {
                              if(principal.Claims.FirstOrDefault(c => c.Type==ClaimTypes.NameIdentifier).Value=="jyalarcon1997")
                              {
                                  var claimsIdentity = principal.Identity as ClaimsIdentity;
                                  claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                              }
                          }
                          await Task.CompletedTask;
                      },
                      OnSignedIn = async context =>
                      {
                          await Task.CompletedTask;

                      },
                      OnValidatePrincipal = async context =>
                      {
                          await Task.CompletedTask;
                      }
                  };


                 });

        }

      
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


            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
