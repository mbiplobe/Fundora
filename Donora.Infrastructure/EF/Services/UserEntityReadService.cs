// using Donora.Application.Services;
// using Donora.Infrastructure.EF.Contexts;
// using Donora.Infrastructure.EF.Models;
// using Microsoft.EntityFrameworkCore;

// namespace Donora.Infrastructure.EF.Services;

// internal sealed class UserEntityReadService : IUserEntityReadService
// {
//     private readonly DbSet<UserReadModel> _userEntity;

//     public UserEntityReadService(ReadDbContext context)
//         => _userEntity = context.Users;

//     public Task<bool> ExistsByNameAsync(string name)
//         => _userEntity.AnyAsync(pl => pl.FullName == name);

  
// }
