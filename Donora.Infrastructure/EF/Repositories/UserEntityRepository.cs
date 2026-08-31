
using Donora.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Donora.Infrastructure.EF.Repositories;

internal sealed class UserEntityRepository : IUserEntityRepository
{
    private readonly DbSet<UserEntity> _userEntities;
    private readonly WriteDbContext _writeDbContext;

    public UserEntityRepository(WriteDbContext writeDbContext)
    {
        _userEntities = writeDbContext.Users;
        _writeDbContext = writeDbContext;
    }

   public Task<UserEntity?> GetAsync(EntityID id)
    => _userEntities.SingleOrDefaultAsync(pl => pl.Id == id);

    public async Task AddAsync(UserEntity userEntity)
    {
        await _userEntities.AddAsync(userEntity);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserEntity userEntity)
    {
        _userEntities.Update(userEntity);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(UserEntity userEntity)
    {
        _userEntities.Remove(userEntity);
        await _writeDbContext.SaveChangesAsync();
    }


}

