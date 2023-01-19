using System.Reflection;
using Application;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerUI;


namespace Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        internal static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
            services.AddApplication();
         
            services.AddControllers();

           services.AddEndpointsApiExplorer();
           services.AddSwaggerGen();
           

            services.AddCors(options =>
            {
                options.AddPolicy(CorsConstants.AccessControlAllowOrigin, builder =>
                    builder.WithOrigins("*")
                        .WithHeaders("*")
                        .WithMethods("*")
                        .WithExposedHeaders("Content-Disposition")
                );
            });
           
           
            
          
           services.AddOptions();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (Configuration["ComponentConfig:Environment"].Equals("Development"))
            {
                app.UseDeveloperExceptionPage();
              
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.EnableFilter("");
                    options.DocExpansion(DocExpansion.None);
                    options.ShowCommonExtensions();
                    options.EnableTryItOutByDefault();
                    options.EnableDeepLinking();
                });

                app.UseDirectoryBrowser();
            }

          

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
           
        }
    }
}