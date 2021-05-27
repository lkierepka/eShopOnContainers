using eShopConContainers.WebSPA;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using Common;

BuildWebHost(args).Run();

IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .ConfigureAppConfiguration((builderContext, config) => { config.AddEnvironmentVariables(); })
        .ConfigureLogging((hostingContext, builder) =>
        {
            builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            builder.AddConsole();
            builder.AddDebug();
            builder.AddAzureWebAppDiagnostics();
        })
        .UseSerilog((builderContext, config) =>
        {
            config.ConfigureSerilogLogger("web-spa", builderContext.Configuration);
        })
        .Build();