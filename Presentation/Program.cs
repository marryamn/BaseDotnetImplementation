using AppCommand;

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

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.UseStartup<Startup>()
                        .UseKestrel(options => { options.Limits.MaxRequestBodySize = 209715200; })
                );
    }
}