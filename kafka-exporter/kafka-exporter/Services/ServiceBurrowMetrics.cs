using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace kafka_exporter.Services
{
    public class ServiceBurrowMetrics : BackgroundService
    {
        //Constantes
        const string ENV_VERIFICATION_DELAY = "verif_delay";

        //variables
        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        
        private int VerificationDelay => Convert.ToInt32(_config.GetSection(ENV_VERIFICATION_DELAY).Value);

        public ServiceBurrowMetrics(ILogger logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.Information("Obtient les métriques Burrow à : {Now}", DateTime.Now);
            
            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.Information("Obtient les métriques Burrow à : {Now}", DateTime.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                //Appel de l'api Burrow
                //...

                await Task.Delay(VerificationDelay, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.Information("Le service d'obtention des métriques Burrow a été arrêté à : {Now}", DateTime.Now);

            await Task.CompletedTask;
        }
    }
}
