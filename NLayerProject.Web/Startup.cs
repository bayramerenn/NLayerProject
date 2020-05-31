using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Service;
using NLayerProject.Core.UnitOfWorks;
using NLayerProject.Data;
using NLayerProject.Data.Repositories;
using NLayerProject.Data.UnitOfWorks;
using NLayerProject.Service.Services;
using NLayerProject.Web.ApiService;

namespace NLayerProject.Web
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpClient<CategoryApiService>(opt =>
            {
                opt.BaseAddress = new Uri(_configuration["baseUrl"]);
            });

            services.AddAutoMapper(typeof(Startup));
            //services.AddDbContext<AppDbContext>(opts =>
            //{
            //    opts.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
            //       b => b.MigrationsAssembly("NLayerProject.API"));
            //});

            //  services.AddAutoMapper(typeof(Startup));

            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<IProductService, ProductService>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{Controller=Categories}/{Action=Index}/{id?}");
            });
        }
    }
}
