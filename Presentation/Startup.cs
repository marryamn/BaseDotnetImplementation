using System.Reflection;
using System.Text;
using Application;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Presentation.Filter;
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
           services.AddHttpContextAccessor();
           services.AddMvc(options => { options.Filters.Add<UserAuthorize>(); });
           services.AddSwaggerGen(options => {
              
               options.SwaggerDoc(
                   "V1 UserSwagger",
                   new OpenApiInfo
                   {
                       Title = "BaseImplementation", Version ="V1 UserSwagger"
                   }
               );
               options.SwaggerDoc(
                   "V1 AdminSwagger",
                   new OpenApiInfo
                   {
                       Title = "BaseImplementation", Version = "V1 AdminSwagger"
                   }
               );
               options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                   Name = "Authorization",
                   Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                   Scheme = "Bearer",
                   BearerFormat = "JWT",
                   In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                   Description = "JWT Authorization header using the Bearer scheme."
               });
               options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
                   {
                       new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                           Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                               Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                               Id = "Bearer"
                           }
                       },
                       new string[] {}
                   }
               });
               /*var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
               var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);*/
           });

            services.AddCors(options =>
            {
                options.AddPolicy(CorsConstants.AccessControlAllowOrigin, builder =>
                    builder.WithOrigins("*")
                        .WithHeaders("*")
                        .WithMethods("*")
                        .WithExposedHeaders("Content-Disposition")
                );
            });
           
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    policy => policy.RequireRole("Admin"));
                
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("User",
                    policy => policy.RequireRole("User"));
                
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
                    options.SwaggerEndpoint($"/swagger/V1 UserSwagger/swagger.json", "V1 UserSwagger");
                    options.SwaggerEndpoint($"/swagger/V1 AdminSwagger/swagger.json", "V1 AdminSwagger");
                      

                    options.EnableFilter("");
                    options.DocExpansion(DocExpansion.None);
                    //options.EnablePersistAuthorization();
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