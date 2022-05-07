using Castle.Core.Logging;
using CronNET;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Utils.Reporting
{
    public class ReportService : IHostedService
    {
        private static readonly CronDaemon cron_daemon = new CronDaemon();

        private ReportManager manager;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if(manager == null)
                this.manager = new ReportManager(cron_daemon);
            
            this.manager.Initialize();
            //this.manager.SendReport("davidmusil777@seznam.cz", new List<Stats>());
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.manager = null;
            return Task.CompletedTask;
        }
    }
}
