using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using NZ01;

namespace HelloWorldLog4Net
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole();
            loggerFactory.AddLog4Net();

            //////////////////////////////////////////////////////////////////////////////////////////////
            // Add logging middleware: This is for recording the http request and response in log files.
            app.UseMiddleware<LogRequestAndResponseMiddleware>();

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "controller-action", template: "{controller}/{action}"); // Exercise: localhost:55109/HelloWorld/Index

                routes.MapRoute(name: "default", template: "{controller=HelloWorld}/{action=Index}"); // Exercise: localhost:55109
            });
        }
    }
}
