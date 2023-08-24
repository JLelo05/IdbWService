using WritingInfluxDB;
using Serilog;
using Serilog.Events;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Log.Logger =  new LoggerConfiguration().MinimumLevel.Debug().MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext().WriteTo
            .File(@"C:\inSight\InfluxServiceLogFile.txt")
            .CreateLogger();
        try
        {
            Log.Information("Start service " + DateTime.Now);
            IHost host = Host.CreateDefaultBuilder(args).UseWindowsService()
           .ConfigureServices(services =>
           {
               services.AddHostedService<Worker>();
           }).UseSerilog().Build();
            await host.RunAsync();
            return;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Problem with strating service");
            return;
        }
        finally
        {
            Log.CloseAndFlush();
        }


    }
}