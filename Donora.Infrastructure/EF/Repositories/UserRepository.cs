using Donora.Domain.Entities;
using Donora.Domain.Repositories;
using Donora.Infrastructure.EF;

using Microsoft.EntityFrameworkCore;

namespace Donora.Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly FundoraDbContext _dbContext;

    public UserRepository(FundoraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserEntity?> GetAsync(Guid id)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserEntity?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<UserEntity?> GetByMobileAsync(string mobile)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Mobile == mobile);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _dbContext.Users
            .AnyAsync(x => x.Email == email);
    }

    public async Task<bool> ExistsByMobileAsync(string mobile)
    {
        return await _dbContext.Users
            .AnyAsync(x => x.Mobile == mobile);
    }

    public async Task AddAsync(UserEntity entity)
    {
        await _dbContext.Users.AddAsync(entity);
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