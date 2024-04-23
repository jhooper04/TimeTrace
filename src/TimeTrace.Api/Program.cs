using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using TimeTrace.Infrastructure.Data;
using TimeTrace.Application.Features.Identity;

namespace TimeTrace.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddEnvironmentVariables("_APP_");
            builder.Configuration.AddCommandLine(args);

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddWebApiServices(builder.Environment, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                await app.InitialiseDatabaseAsync();
            }

            app.UseHttpsRedirection();
            //app.UseStatusCodePages();
            //app.UseCors(corsPolicy);
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseSwaggerUi(settings =>
            {
                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";
            });

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller}/{action=Index}/{id?}");

            //app.MapRazorPages();

            //app.MapFallbackToFile("index.html");

            app.UseExceptionHandler(options => { });

            //app.Map("/", () => Results.Redirect("/api"));

            //app.MapEndpoints();

            app.MapControllers();
        }
    }
}
