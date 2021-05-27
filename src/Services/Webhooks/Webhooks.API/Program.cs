using Common;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Webhooks.API;
using Webhooks.API.Infrastructure;

CreateWebHostBuilder(args).Build()
    .MigrateDbContext<WebhooksContext>((_, __) => { })
    .Run();


IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddEnvironmentVariables();
                })
                .UseSerilog((context, configuration) => configuration.ConfigureSerilogLogger("webhooks-api", context.Configuration));