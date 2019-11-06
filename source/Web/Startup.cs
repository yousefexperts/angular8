using DotNetCore.AspNetCore;
using DotNetCore.IoC;
using DotNetCoreArchitecture.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Core.Infra.Context;
namespace DotNetCoreArchitecture.Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.Use(async (context, next) =>
            {
                List<KeyValuePair<string, StringValues>> cacheControlHeaders = context.Request.Headers.Where(x => x.Key.Trim().ToLower() == "cache-control" && x.Value.Count > 0 && (x.Value.Aggregate((y, z) => y + z).Trim().ToLower() == "no-cache" || x.Value.Aggregate((y, z) => y + z).Trim().ToLower() == "no-store")).ToList();
                foreach (var cacheControlHeader in cacheControlHeaders)
                {
                    context.Request.Headers.Remove(cacheControlHeader);
                }
                await next();
            });
            application.UseException();
            application.UseRouting();
            application.UseCorsAllowAny();
            application.UseHttps();
            application.UseAuthentication();
            application.UseAuthorization();
            application.UseResponseCompression();
            application.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });
            application.UseEndpoints(endpoints => endpoints.MapControllers());
            InitializeDatabase(application);
            application.UseSpa(spa =>
            {
                spa.Options.SourcePath = "FrontEnd";
                spa.Options.StartupTimeout = new TimeSpan(0, 10, 60);
                spa.UseAngularCliServer(npmScript: "start");
            });
            application.UseResponseCaching();
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<NorthwindContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<Context>().Database.Migrate();
            }
        }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogger();
            services.AddCors();
            services.AddSecurity();
            services.AddResponseCompression();
            services.AddResponseCaching();
            services.AddControllers();
            services.AddMvcJson();
            services.AddSpa();
            services.AddFileService();
            services.AddApplicationServices();
            services.AddDatabaseServices();
            services.AddInfraServices();
            services.AddContext();
            services.AddDbContext<Context>(options => options.UseSqlServer("Server=NEWSOFT-TR02;Database=HrModule;User Id=sa; Password=opc@2018;"));
            services.AddScoped<NorthwindContext, NorthwindContext>();
            services.AddScoped<Context, Context>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState);

                    var result = new BadRequestObjectResult(problemDetails);

                    result.ContentTypes.Add("application/problem+json");
                    result.ContentTypes.Add("application/problem+xml");

                    return result;
                };
            });

        }
    }
}
