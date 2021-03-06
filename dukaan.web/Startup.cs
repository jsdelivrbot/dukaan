﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dukaan.web.Infrastructure.Ioc;
using dukaan.web.Infrastructure.ModelBinders;
using dukaan.web.Infrastructure.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dukaan.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new ShoppingCartModelBinderProvider());
                options.ModelBinderProviders.Insert(0, new NodeModelBinderProvider());
                options.ModelBinderProviders.Insert(0, new ContentModelBinderProvider(Configuration));
            });
            services.AddDukaan(Configuration);
            services.AddSingleton(Configuration);            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routeBuildler =>
            {
                routeBuildler
                    .MapPageRoute("pagewebsiterouting", $"{{*{PageRoute.FriendlyUrlRouteDataValueKey}}}");
            });
        }
    }
}
