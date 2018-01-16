using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AddressBook.Models;
using AddressBook.Resources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;

namespace AddressBook
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
            services.AddLocalization(options => options.ResourcesPath = "");

            services.Configure<RequestLocalizationOptions>(
                opts =>
                {
                    var supportedCultures = new[]
                    {
                        new CultureInfo("sv-SE"),
                        new CultureInfo("en-US"),
                        new CultureInfo("bn-BD")
                    };
                    opts.DefaultRequestCulture = new RequestCulture("sv-SE");
                    opts.SupportedCultures = supportedCultures;
                    opts.SupportedUICultures = supportedCultures;
                    opts.RequestCultureProviders = new List<IRequestCultureProvider>
                    {
                        new QueryStringRequestCultureProvider(),
                        new CookieRequestCultureProvider()
                    };
                }
            );

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix); 
               
            services.AddDbContext<AddressBookContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AddressBookContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRequestLocalization();

            app.UseMvc(routes =>
            {
                    routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }
    }
}
