using System.Reflection;
using Donora.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Donora.Shared.Queries;

    public static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddScoped<IQueryDispatcher, InMemoryQueryDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

     

            return services;
        }
    }

