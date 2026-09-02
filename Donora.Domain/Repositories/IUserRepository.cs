

using Donora.Domain.Entities;

namespace Donora.Domain.Repositories;

public interface IUserRepository
{
    Task AddAsync(UserEntity entity);

    Task UpdateAsync(UserEntity entity);

    Task DeleteAsync(UserEntity entity);
}