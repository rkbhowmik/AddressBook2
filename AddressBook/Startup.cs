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
using Microsoft.AspNetCore.Localization;

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
            services.AddLocalization(options => options.ResourcesPath = "");  // Globalization and Localization process

            services.AddMvc()
                .AddViewLocalization()              //This line is also included in Globalization and Localization process
                .AddDataAnnotationsLocalization();  // This line as well 

            services.AddDbContext<AddressBookContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AddressBookContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.



        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.Use((ctx, next) =>
            //{
            //    var sv = new CultureInfo("sv-SE");
            //    System.Threading.Thread.CurrentThread.CurrentCulture = sv;
            //    System.Threading.Thread.CurrentThread.CurrentUICulture = sv;

            //    return next();
            //});

            List<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("sv-SE"),
                new CultureInfo("en-US"),
                new CultureInfo("bn-BD")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("sv-SE"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

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

            app.UseMvc(routes =>
            {
                    routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }
    }
}
