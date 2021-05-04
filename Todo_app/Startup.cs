using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data_Access_Layer;
using Microsoft.Extensions.Configuration;
using Data_Access_Layer.Repositories;
using MediatR;
using Business_Logic_Layer.Handlers.TodoHandler;

namespace Todo_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));

            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().WithOrigins("http://localhost:3000");
                    policy.AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();

            services.AddMediatR(typeof(GetAllTodosHandler).Assembly);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               // app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            //app.UseMvc();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
