using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Data;
using WebREST_EF_50.Services;

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
			
			services.AddDbContext<DataContext>(
				x => x.UseSqlite(Configuration.GetConnectionString("SQLite"))
				);
			services.AddControllers();
			
			// To prevent cyclic references(?)
			services.AddControllers().AddNewtonsoftJson();
			services.AddControllersWithViews().AddNewtonsoftJson();
			services.AddRazorPages().AddNewtonsoftJson();
			
			// Add Blazor
			services.AddRazorPages();
			services.AddServerSideBlazor();
			
			services.AddScoped<IUserService, UserService>();
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