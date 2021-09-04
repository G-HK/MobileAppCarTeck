using CarTeckAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using CarTeckAPI.Services;
using Microsoft.AspNetCore.Mvc.Formatters;
using AutoMapper;

namespace CarTeckAPI

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


            services.AddControllers();

            //services.AddControllers(options =>
            //{
            //    options.RespectBrowserAcceptHeader = true; // false by default
            //});


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarTeckAPI", Version = "v1" });
            //});

            //services.AddMvc(options => options.EnableEndpointRouting = false)
            //  .AddMvcOptions(opts =>
            //  {
            //      opts.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());

            //  });
            services.AddRazorPages();

            services.AddDbContext<CarTeckInfoContext>(opts =>
           opts.UseSqlServer(Configuration["ConnectionStrings:CarTeckDBConnectionString"]));


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarTeckAPI v1"));
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //endpoints.MapControllerRoute(
                //    name : "Default",
                //    pattern: "{controller=HomeController}/{action=index}/{id?}");
                //endpoints.MapRazorPages();
            });

            app.UseStatusCodePages();

            SeedUserData.EnsurePopulated(app);
        }
    }
}
