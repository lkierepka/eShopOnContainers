using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Formatting.Compact;

namespace Common
{
    public static class CommonConfigurationExtensions
    {
        public static ILogger CreateSerilogLogger(string appName, IConfiguration configuration = null)
        {
            return new LoggerConfiguration()
                .ConfigureSerilogLogger(appName, configuration)
                .CreateLogger();
        }

        public static LoggerConfiguration ConfigureSerilogLogger(this LoggerConfiguration loggerConfiguration,
            string appName, IConfiguration configuration)
        {
            loggerConfiguration.MinimumLevel.Information()
                .Enrich.WithProperty("ApplicationContext", appName)
                .Enrich.FromLogContext()
                .Enrich.With<ElasticsearchEnricher>()
                .WriteTo.Console(new CompactJsonFormatter());
            if (configuration != null)
                loggerConfiguration.ReadFrom.Configuration(configuration);
            return loggerConfiguration;
        }
    }
}