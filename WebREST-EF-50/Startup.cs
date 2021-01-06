using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;
using WebREST_EF_50.Services;
using WebREST_EF_50.Services.Companies;
using WebREST_EF_50.Services.Employees;
using WebREST_EF_50.Services.Objectives;
using WebREST_EF_50.Services.PhonesEmails;
using WebREST_EF_50.Services.Projects;
using WebREST_EF_50.Services.Users;

namespace WebREST_EF_50
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
            // DbContext for REST API
            services.AddDbContext<DataContext>(
                x => x.UseSqlite(Configuration.GetConnectionString("SQLite"))
            );

            // DbContext for Blazor...
            // services.AddDbContextFactory<BlazorDataContext>(
            //     options => options.UseSqlite(Configuration.GetConnectionString("SQLite"))
            // );


            services.AddControllers();

            // To prevent cyclic references(?)
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddRazorPages().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            // Add Blazor
            // TODO: EF - DbContext lifetime! https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/#using-a-dbcontext-factory-eg-for-blazor
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // TODO: Add Admin
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IObjectiveService, ObjectiveService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IPhonesEmailService, PhonesEmailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}