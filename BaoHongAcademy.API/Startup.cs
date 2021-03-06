using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaoHongAcademy.API.Interfaces;
using BaoHongAcademy.API.Services;
using BaoHongAcademy.Infrastructure;
using BaoHongAcademy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BaoHongAcademy.API.Helpers;
using BaoHongAcademy.API.Middleware;
using BaoHongAcademy.Infrastructure.Helpers;
using BaoHongAcademy.API.Helpers.OptionConfigurations;
using Microsoft.AspNetCore.Routing;

namespace BaoHongAcademy.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.Configure<RouteOptions>(options => {
                options.LowercaseUrls = true;
            });

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = Configuration.GetSection("Authentication:Google:ClientId").ToString();
                options.ClientSecret = Configuration.GetSection("Authentication:Google:ClientSecret").ToString();
            });

            services.AddDbContext<BaoHongContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            DatabaseHelper.connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddScoped<IUserService, UserService>();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BaoHongAcademy.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaoHongAcademy.API v1"));
            }

            // Create the database
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<BaoHongContext>();
                //context.Database.EnsureCreated();
                context.Database.Migrate();
                DbInitializer.Initialize(context);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            // Global error handler
            app.UseHandleErrorMiddleware();

            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(MyAllowSpecificOrigins);
            });
        }
    }
}
