using System;
using ELaw.Areas.Identity.Data;
using ELaw.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ELaw.Areas.Identity.IdentityHostingStartup))]
namespace ELaw.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ELawDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ELawDbContextConnection")));

                services.AddDefaultIdentity<ELawUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<ELawDbContext>();
            });
        }
    }
}