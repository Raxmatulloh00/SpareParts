using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBot
{
    public class Worker : BackgroundService
    {
        private BotListener listener;
        public Worker(BotListener botListener, IConfiguration configuration, IHostEnvironment builder)
        {
            this.listener = botListener;
            //updateDockerFiles(configuration);
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            listener.Work();
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000, stoppingToken);
        }

        //public override Task StopAsync(CancellationToken cancellationToken)
        //{
        //    if (listener != null)
        //        listener.StopListener();
        //    try
        //    {
        //        UserStaticData.SaveAllData();
        //    }
        //    catch (Exception error)
        //    {
        //        Logger.Log("SaveAllData", error);
        //    }
        //    Logger.Log("Service stopping at: " + DateTime.Now);
        //    return base.StopAsync(cancellationToken);
        //}

        
    }
}
