using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskOne.Infrastructure;
using TaskOne.Models.Data;
using TaskOne.Models.Seeder;
using TaskOne.Service;
using TaskOne.Service.Abstract;
using TaskOne.Service.Implementation;

namespace TaskOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //---- My Services----------
            #region myService

            #region dbContext
            builder.Services.AddDbContext<AppDbContext>(
             o => o.UseSqlServer(builder.Configuration.
             GetConnectionString("defualtConnection"))
             );

            #endregion

            #region Cors
            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("MyPolicy", corsPolicyBuilder =>
                {
                    corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });
            });
            #endregion
            #region DI
            builder.Services.AddInfrustructureDependencies()
                .AddServicesDependencies();
            #endregion
            #endregion

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("MyPolicy");

            app.UseAuthorization();

            // DataSeeder!

          

            app.MapControllerRoute(
            name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
