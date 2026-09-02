using Donora.Domain.Entities;

namespace Donora.Domain.Repositories;

public interface IUserRepository
{
    Task<UserEntity?> GetAsync(Guid id);

    Task AddAsync(UserEntity entity);

    Task UpdateAsync(UserEntity entity);

    Task DeleteAsync(UserEntity entity);
}