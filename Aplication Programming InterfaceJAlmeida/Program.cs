using Aplication_Programming_InterfaceJAlmeida;
using Microsoft.AspNetCore;
using Serilog;
/*
var app = Startup.InicializarApp(args);
app.Run();  */
namespace Aplication_Programming_InterfaceJAlmeida
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            try
            {
                Log.Information("Starting up");
                //CreateHostBuilder(args).Build().Run();
                var app = Startup.InicializarApp(args);
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args).UseSerilog()
               .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }).UseWindowsService();

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseSerilog()
                .ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) =>
                {

                })
                .UseStartup<Startup>()
                .Build();
    }
}