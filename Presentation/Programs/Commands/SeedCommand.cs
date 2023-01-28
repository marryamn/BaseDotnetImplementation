using AppCommand.Abstracts;
using AppCommand.Attributes;
using Ef.Seeder;
using Infrastructure;
using Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Programs.Commands;
[Command("seed")]
public class SeedCommand: AbstractCommand
{
    public ILogger<SeedCommand> Logger { get; set; }
    public IServiceProvider ServiceProvider { get; set; }

    public SeedCommand(ILogger<SeedCommand> logger,IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        Logger = logger;
    }

    public override Task Run(string[] args, CancellationToken cancellationToken = default)
    {
     
            
        new DatabaseSeeder(ServiceProvider,
                ServiceProvider.GetService<AppDbContext>())
            .IsProductionEnvironment(false)
            .EnsureSeeded(true);
        // Implement what you want.
        Logger.LogInformation("Hi there!!!");
        var applicationArgs = args.Aggregate((x, y) => x += $" {y}");
        Logger.LogInformation("ApplicationArgs = {applicationArgs}", applicationArgs);
        Thread.Sleep(100);
        return Task.CompletedTask;

    }

}