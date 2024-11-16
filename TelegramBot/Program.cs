using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot.Types;

namespace TelegramBot
{
    public class Program
    {

        //static void Main(string[] args)
        //{
        //    BotListener updat_Eror = new BotListener();
        //    Console.WriteLine("hello World");
        //   updat_Eror.Work();
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .AddJsonFile("appsettings.json")
                    .Build();

            CreateHostBuilder(args, configuration).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args, IConfigurationRoot config) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder =>
                {
                    builder.Sources.Clear();
                    builder.AddConfiguration(config);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<BotListener>();
                });


    }
}	