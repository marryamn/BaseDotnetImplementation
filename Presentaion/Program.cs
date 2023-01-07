
/*
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args).Build();

IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(config);
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//postgres


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/

using AppCommand;
using Presentaion;

namespace Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            CommandManager.SearchForCommands();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()){
                CommandManager.SetServiceProvider(scope.ServiceProvider);
                await CommandManager.InvokeCommand(args);
            }
            
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>()
                        .UseKestrel()
                );
    }
    
}