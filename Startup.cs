using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using webapiInsurer.Models;
using webapiInsurer.Repositories;
using Microsoft.AspNetCore.Server.IISIntegration;



namespace webapiInsurer
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<webapiInsurer.Models.ApplicationContext>(opts =>opts.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"],x => x.MigrationsAssembly("WebApplication")));
            services.AddScoped(typeof(IDataAccess<Contracts, string>), typeof(DataAccessRepository));
            services.AddScoped(typeof(IDataAccess<Insert_Contract_Post_Method_API, string>), typeof(DataAccessRepository));
            services.AddScoped(typeof(IDataAccess<Update_Contract_PUT_Method_API, string>), typeof(DataAccessRepository));
            services.AddMvc();
            services.AddAuthentication(Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
