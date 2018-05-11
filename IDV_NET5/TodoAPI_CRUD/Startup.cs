using System;
using System.Collections.Generic;
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
using TodoAPI_CRUD.Models;
using TodoAPI_CRUD.Models.Repositories;


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


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //                name: "default",
            //                template: "api/{controller}/{action}");
            //});


            //app.Run(async (Context) =>
            //{
            //    await Context.Response.WriteAsync("coco");
            //});
        }
        //public static void RegisterRouter(RouteCollection routes)
        //{
        //    routes.MapRoute(
        //        "Default",
        //        "{controller}/{action}/{id}",
        //        new { controller = "Home", action = "Index", id = "" }
        //        );
        //}
    }
}
