using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using polozi_ba.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using polozi_ba.Data.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.UI.Services;
using polozi_ba.Service;

namespace polozi_ba
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IServiceProvider Service { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //baza i identity
            services.AddDbContext<PoloziBaContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<Korisnik, IdentityRole>()
                .AddEntityFrameworkStores<PoloziBaContext>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = false;
            });

            //FB AUTH
            services.AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = "346508559443989";
                    options.AppSecret = "7867bb5d8de5d09d02805ac4e4a9cf56";
                    options.SaveTokens = true;
                    options.ClaimActions.MapJsonKey(ClaimTypes.DateOfBirth, "birthday");
                    options.Scope.Add("public_profile");
                    options.Fields.Add("birthday");
                    options.Fields.Add("picture");
                    options.Fields.Add("name");
                    options.Fields.Add("email");
                    options.Fields.Add("gender");


                });


            services.AddScoped<IPredmet, polozi_ba.Service.PredmetService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IGrad, GradService>();
            services.AddScoped<IPoloziBa, PoloziBaService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service)
        {
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
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "api",
                    template: "api/{cocontroller}/{action}/{id}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }
}
