using Glimpse;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using ULaval.LunchTi.Models;
using ULaval.LunchTi.Services;

namespace ULaval.LunchTi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ULavalLunchTiContext>(options =>
                    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ULavalLunchTiContext-0c8ee4b7-1e61-4f48-a290-46160646484d;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddSwaggerGen();
            services.AddGlimpse();

            services.AddTransient<ITodoItemsService, TodoItemsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseMvc(routes => routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"));
            app.UseSwaggerGen();
            app.UseSwaggerUi();

            if (env.IsDevelopment())
            {
                app.UseRuntimeInfoPage();
                app.UseDeveloperExceptionPage();
                app.UseGlimpse();
                app.UseBrowserLink();
            }
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
