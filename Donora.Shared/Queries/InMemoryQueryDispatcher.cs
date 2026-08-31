using Donora.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Donora.Shared.Queries;

internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();

            var handlerType = typeof(IQueryHandler<,>)
         .MakeGenericType(query.GetType(), typeof(TResult));

            var handler = scope.ServiceProvider.GetRequiredService(handlerType);

            var method = handlerType.GetMethod("HandleAsync");

            if (method == null)
                throw new Exception($"HandleAsync not found on {handlerType.Name}");

            return await (Task<TResult>)method.Invoke(handler, new object[] { query })!;
        }
        catch (Exception e)
        {
            throw new Exception($"Error dispatching query of type {query.GetType().Name}: {e.Message}");
        }
    }
}