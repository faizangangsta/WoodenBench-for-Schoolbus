﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WBPlatform.WebManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAntiforgery();
            services.AddCors();
            services.AddApplicationInsightsTelemetry();
            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseCors();
            app.UseHsts();
            app.UseHttpsRedirection();
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Home/Error");
            }
            app.UseMvc(routes => { routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"); });
        }
    }
}
