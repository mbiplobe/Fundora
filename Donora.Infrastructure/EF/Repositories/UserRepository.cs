using Donora.Domain.Entities;
using Donora.Domain.Repositories;
using Donora.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Donora.Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly WriteDbContext _dbContext;

    public UserRepository(WriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

public async Task AddAsync(UserEntity entity)
{
    try
    {
        var connection = _dbContext.Database.GetDbConnection();

        Console.WriteLine($"Database: {connection.Database}");
        Console.WriteLine($"DataSource: {connection.DataSource}");
        Console.WriteLine($"Connection: {connection.ConnectionString}");

        await _dbContext.Users.AddAsync(entity);

        Console.WriteLine(
            $"Entity State: {_dbContext.Entry(entity).State}"
        );

        var rows = await _dbContext.SaveChangesAsync();

        Console.WriteLine($"Affected Rows: {rows}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        throw;
    }
}

    public   Task UpdateAsync(UserEntity entity)
    {
        _dbContext.Users.Update(entity);
       _dbContext.SaveChangesAsync();

        return Task.CompletedTask;
    }

    public Task DeleteAsync(UserEntity entity)
    {
        _dbContext.Users.Remove(entity);

        return Task.CompletedTask;
    }
}