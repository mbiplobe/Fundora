using Donora.Infrastructure.EF;
using Donora.Infrastructure.Logging;
using Donora.Shared.Abstractions.Commands;
using Donora.Shared.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Donora.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSQLDB(configuration);
        services.AddQueries();
        services.AddSerilog(configuration);
        //services.AddSingleton<IExternalService, ExternalService>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }
}
