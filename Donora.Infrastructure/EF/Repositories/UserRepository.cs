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
        }
        catch (Exception ex)
        {
            // Handle the exception or log it as needed
            throw new InvalidOperationException("An error occurred while adding the user.", ex);
        }
       // await _dbContext.Users.AddAsync(entity);
    }

    public Task UpdateAsync(UserEntity entity)
    {
        _dbContext.Users.Update(entity);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(UserEntity entity)
    {
        _dbContext.Users.Remove(entity);

        return Task.CompletedTask;
    }
}