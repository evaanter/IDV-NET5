using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Swashbuckle.AspNetCore.Swagger;
using TodoAPI_CRUD.Models;




namespace TodoAPI_CRUD
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
            services.AddDbContext<ApplicationContext>(opts =>
                         opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = " API",
                    Version = "v1",
                    Description = "The documentation of  API"
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "TodoAPI.xml");
                c.IncludeXmlComments(xmlPath);
            });

            // authoriser localhost
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:50442").Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationContext applicontext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //  app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=api}/{action=FicheCentral}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            // Shows UseCors with named policy
            app.UseCors("AllowSpecificOrigin");


            //applicontext.Database.EnsureCreated();
            //app.Run(async (Context) =>
            //{
            //    await Context.Response.WriteAsync("coco");
            //});
        }
    }
}
