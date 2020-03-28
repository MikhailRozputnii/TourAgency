using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using TourAgency.Api.Configuration.Mapper;
using TourAgency.BLL.Configuration.Mapper;
using TourAgency.BLL.Dtos;
using TourAgency.BLL.Services;
using TourAgency.BLL.Services.Implement;
using TourAgency.DAL.Data;
using TourAgency.DAL.Data.Entities;
using TourAgency.DAL.Data.Repositories;
using TourAgency.DAL.Data.Repositories.Implementation;

namespace TourAgency.Api
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
            services.AddDbContext<AppDbContext>(options => options
               .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(typeof(DtoProfile).Assembly, typeof(ViewModelProfile).Assembly);
            services.AddScoped<IUnitOfWork, BaseUnitOfWork>();
            services.AddScoped<IEntityService<TourDto>, TourService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/api/error");
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/api/error");
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}");
            });

            loggerFactory.AddFile($"Log/TourAgency-{DateTime.Now.Date}.txt", LogLevel.Information);
        }
    }
}