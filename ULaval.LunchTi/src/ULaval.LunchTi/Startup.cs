using Glimpse;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ULaval.LunchTi.Models;
using ULaval.LunchTi.Services;

namespace ULaval.LunchTi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var useInMemoryDatabase = !string.IsNullOrEmpty(Configuration["Data:UseInMemoryDatabase"]);
            if (useInMemoryDatabase)
            {
                services.AddEntityFramework()
                    .AddInMemoryDatabase()
                    .AddDbContext<ULavalLunchTiContext>(options => 
                    options.UseInMemoryDatabase());
            }
            else
            {
                services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<ULavalLunchTiContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            }

            services.AddSwaggerGen();
            services.AddGlimpse();

            services.AddTransient<ITodoItemsService, TodoItemsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseSwaggerGen();
            app.UseSwaggerUi();

            if (env.IsDevelopment())
            {
                app.UseRuntimeInfoPage();
                app.UseDeveloperExceptionPage();
                app.UseGlimpse();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
