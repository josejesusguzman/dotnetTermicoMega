using Serilog;
using Servicio.Sensor;
using Servicio.Metrics;

var builder = Host.CreateApplicationBuilder(args);


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .WriteTo.File(
        path: "logs/termicologs-.csv",
        outputTemplate: "{Timestamp:0};{Message:lj}{NewLine}",
        rollingInterval: RollingInterval.Day
    ).CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

