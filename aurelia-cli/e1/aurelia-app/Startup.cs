using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.AspNetCore.SpaServices.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace WebApplicationBasic
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
			// Add framework services.
			//services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddControllersWithViews();
			
			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "/";
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			//if (env.IsDevelopment())
			//{
			//	app.UseDeveloperExceptionPage();
			//	app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
			//	{
			//		HotModuleReplacement = true,
			//		ConfigFile = "webpack.netcore.config.js",
			//		HotModuleReplacementClientOptions = new Dictionary<string, string>{
			//		{"reload", "true"}
			//	  }
			//	});
			//}
			//else
			//{
			//	app.UseExceptionHandler("/Home/Error");
			//	app.UseHsts();
			//}

			//app.UseHttpsRedirection();
			//app.UseStaticFiles();

			//app.UseMvc(routes =>
			//{
			//	routes.MapRoute(
			//		name: "default",
			//		template: "{controller=Home}/{action=Index}/{id?}");

			//	routes.MapSpaFallbackRoute(
			//	  name: "spa-fallback",
			//	  defaults: new { controller = "Home", action = "Index" });
			//});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

				app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
				{
					HotModuleReplacement = true,
					ConfigFile = "webpack.config.js",
					HotModuleReplacementClientOptions = new Dictionary<string, string> { { "reload", "true" } }
				});
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			//app.UseSpa(spa =>
			//{
			//	// To learn more about options for serving an Angular SPA from ASP.NET Core,
			//	// see https://go.microsoft.com/fwlink/?linkid=864501

			//	//spa.Options.SourcePath = "src";

			//	if (env.IsDevelopment())
			//	{
			//		spa.UseProxyToSpaDevelopmentServer("http://localhost:5000");
			//	}
			//});
		}
	}
}
