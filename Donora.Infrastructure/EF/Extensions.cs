using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Donora.Infrastructure.EF.Contexts;
using Donora.Infrastructure.EF.Options;


namespace Donora.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddScoped<ISubjectRepository, SubjectRepository>();
        // services.AddScoped<IClassRepository, ClassEntityRepository>();
        // services.AddScoped<ISectionRepository, SectionRepository>();
        // services.AddScoped<IUserEntityRepository, UserEntityRepository>();
        // services.AddScoped<IUserEntityReadService, UserEntityReadService>();

        var options = configuration.GetSection("DataBaseConnectionString").Get<DataBaseOptions>();

        var connectionString = options?.ConnectionString ?? throw new InvalidOperationException("Database connection string is not configured.");
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        services.AddDbContext<ReadDbContext>(ctx =>
            ctx.UseMySql(options.ConnectionString, serverVersion));

        services.AddDbContext<WriteDbContext>(ctx =>
            ctx.UseMySql(options.ConnectionString, serverVersion));

        return services;
    }

}
