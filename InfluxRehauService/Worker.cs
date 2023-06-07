using app.Invocables;
using app.Services;
using Coravel;
using Coravel.Scheduling.Schedule;
using InfluxDB.Client.Api.Domain;
using LibDataHandler.Services;
using LibMySqlConnection.Services;
using Microsoft.AspNetCore.Builder;
using System.Net;

namespace WritingInfluxDB
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConfiguration ClientConfig;
        private InfluxWriteData clientInfluxDB;
        private ServiceMySqlConnection clientMySql;
        private IApplicationBuilder AppBuilder;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            ClientConfig = configuration;
            clientMySql = new ServiceMySqlConnection(ClientConfig);
            clientInfluxDB = new InfluxWriteData(new InfluxDBService(ClientConfig),clientMySql);
            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<InfluxDBService>();
            services.AddTransient<InfluxWriteData>();
            services.AddTransient<ServiceMySqlConnection>();
            services.AddScheduler();
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service has stopped.");
            return base.StopAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Task conection = clientInfluxDB.Invoke();
                if ( conection.IsFaulted)
                {
                    _logger.LogError("Fault ", conection.Status);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}