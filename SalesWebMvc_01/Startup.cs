﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc_01.Models;
using SalesWebMvc_01.Data;
using SalesWebMvc_01.Services;

namespace SalesWebMvc_01
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddDbContext<SalesWebMvc_01Context>(options =>
			options.UseMySql(Configuration.GetConnectionString("SalesWebMvc_01Context"), builder =>
               builder.MigrationsAssembly("SalesWebMvc_01")));

			services.AddScoped<SeedingService>();
			services.AddScoped<SellerService>();
			services.AddScoped<DepartmentService>();
			services.AddScoped<SalesRecordService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env,SeedingService seedingService)
		{
			var enUs = new CultureInfo("en-Us");
			var localizationOptions = new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture(enUs),
				SupportedCultures = new List<CultureInfo> { enUs },
				SupportedUICultures = new List<CultureInfo> { enUs }
			};
			app.UseRequestLocalization(localizationOptions);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				seedingService.Seed();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
