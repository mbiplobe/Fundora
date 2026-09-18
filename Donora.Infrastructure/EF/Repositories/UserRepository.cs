using Donora.Domain.Entities;
using Donora.Domain.Repositories;
using Donora.Infrastructure.EF.Contexts;

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
            await _dbContext.Users.AddAsync(entity);
            var rows = await _dbContext.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }

    public Task UpdateAsync(UserEntity entity)
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