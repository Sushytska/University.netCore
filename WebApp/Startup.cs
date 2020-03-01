using AutoMapper;
using BLL;
using BLL.Interfaces;
using BLL.Managers;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.DataContext;
using Entities.DTOModels;
using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApp
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
            services.AddControllersWithViews();

            services.AddDbContext<UniversityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UniversityContext")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IValidator, AttributeValidator>();

            services.AddScoped<IRepository<Department>, DepartmentRepository>();
            services.AddScoped<IRepository<Faculty>, FacultyRepository>();
            services.AddScoped<IRepository<Group>, GroupRepository>();
            services.AddScoped<IRepository<Speciality>, SpecialityRepository>();
            services.AddScoped<IRepository<Student>, StudentRepository>();

            services.AddScoped<IManager<DepartmentDTO>, DepartmentManager>();
            services.AddScoped<IManager<FacultyDTO>, FacultyManager>();
            services.AddScoped<IManager<GroupDTO>, GroupManager>();
            services.AddScoped<IManager<SpecialityDTO>, SpecialityManager>();
            services.AddScoped<IManager<StudentDTO>, StudentManager>();
            
            var config = new Mapping().Configure();
            services.AddSingleton<IMapper>(sp => config.CreateMapper());
         
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
    
}