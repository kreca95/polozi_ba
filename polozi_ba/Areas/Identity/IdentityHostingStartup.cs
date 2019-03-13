using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using polozi_ba.Data;
using polozi_ba.Data.Models;
using polozi_ba.Models;

[assembly: HostingStartup(typeof(polozi_ba.Areas.Identity.IdentityHostingStartup))]
namespace polozi_ba.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public IConfiguration Configuration { get; }
        public IdentityHostingStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PoloziBaContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<Korisnik>()
                    .AddEntityFrameworkStores<PoloziBaContext>();
            });
        }
    }
}