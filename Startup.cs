using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using CourseApp.Models.Repository.Abstraction;
using CourseApp.Models.Repository.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace CourseApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.EnableEndpointRouting = false);

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DataConnection"));

                opt.EnableSensitiveDataLogging(true);
            });

            services.AddDbContext<UserDbContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("UserDBConnection")));

            //services.AddTransient<IUserRepository, EfUserRepository>();
            services.AddTransient<ICourseRepository, EfCourseRepository>();
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            DataContext context/*, UserDbContext userDbContext*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed(context);
                //SeedDatabase.Seed(userDbContext);
            }

            app.UseDeveloperExceptionPage();

            //wwwroot
            app.UseStaticFiles();

            //node_modules
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                RequestPath = "/node_modules"
            });

            app.UseStatusCodePages();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Course}/{action=Index}/{id?}"
                    );
            });

        }
    }
}
