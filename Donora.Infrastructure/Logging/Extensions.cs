using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace Donora.Infrastructure.Logging;

internal static class Extensions
{
    public static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .Enrich.WithEnvironmentName()
        .Enrich.WithMachineName()
        .WriteTo.Console()
        .WriteTo.Debug()

        
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

        return services;
    }
}