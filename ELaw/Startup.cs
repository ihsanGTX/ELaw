using ELaw.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ELaw.Interfaces.ICascade;
using static ELaw.Repositories.CascadeRepo;

namespace ELaw
{
    public class Startup
    {
        private IConfigurationRoot _config;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            var ConfigBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json");
            _config = ConfigBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddScoped<ILawReview, LawReviewRepo>();
            services.AddScoped<IState, StateRepo>();
            services.AddScoped<ICatchwordLv1, CatchwordLv1Repo>();
            services.AddScoped<ICatchwordLv2, CatchwordLv2Repo>();
            services.AddScoped<ICatchwordLv3, CatchwordLv3Repo>();
            services.AddScoped<ICatchwordLv4, CatchwordLv4Repo>();
            services.AddScoped<ICourtType, CourtTypeRepo>();
            services.AddScoped<IJudgmentCountry, JudgmentCountryRepo>();
            services.AddScoped<IJudgmentLanguage, JudgmentLanguageRepo>();
            services.AddScoped<IJudgeName, JudgeNameRepo>();
            services.AddControllersWithViews();
            services.AddDbContext<EDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ELawDbContextConnection")));
            services.AddRazorPages();
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
