namespace Donora.Application.Services;

public interface IUserEntityReadService
{
    Task<bool> ExistsByNameAsync(string name);

    // Task<UserEntityDto?> GetByIdAsync(GetUserEntity query);
}
