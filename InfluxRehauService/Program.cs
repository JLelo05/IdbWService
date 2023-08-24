using WritingInfluxDB;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //Log.Logger =  new LoggerConfiguration().MinimumLevel.Debug().MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        //    .Enrich.FromLogContext().WriteTo
        //    .File(@"C:\inSight\InfluxServiceLogFile.txt")
        //    .CreateLogger();

        //Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        //   .Enrich.FromLogContext().WriteTo
        //   .MSSqlServer("Server=myServerAddress;Database=myDataBase;User Id=admin;Password=111111;")
        //   .CreateLogger();

        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        var log = config.GetConnectionString("Logs");
        Log.Logger = new LoggerConfiguration().WriteTo
           .MSSqlServer("Server=SQLEXPRESS;Database=systemlogs;User Id=test;Password=111111;", new MSSqlServerSinkOptions() { TableName = "LogEvents"})
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