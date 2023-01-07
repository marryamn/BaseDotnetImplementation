using System.Reflection;
using Application;
using Infrastructure;

using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Presentaion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddDbContextPool<AppDbContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

           // services.AddInfrastructure(Configuration);
            services.AddApplication();
            ConfigSwaggerService(services);
            services.AddCors(options =>
            {
                options.AddPolicy(CorsConstants.AccessControlAllowOrigin, builder =>
                    builder.WithOrigins("*")
                        .WithHeaders("*")
                        .WithMethods("*")
                        .WithExposedHeaders("Content-Disposition")
                );
            });
            //services.AddTransient<ICustomerService, CustomerService>();
           // services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (Configuration["ComponentConfig:Environment"].Equals("Development"))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDirectoryBrowser();
            }
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void ConfigSwaggerService(IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

 
    }
}