
using Donora.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Donora.Infrastructure.Services;

internal sealed class UserRegistrationService : IUserRegistrationService
{
    private readonly ReadDbContext _context;

    public UserRegistrationService(ReadDbContext context)
    {
        _context = context;
    }

    public async Task<ValidationResponse> ValidateAsync(UserRegistrationValidationRequest request)
    {
        try
        {
            if (await _context.Users
           .AnyAsync(x => x.Email == request.Email))
            {
                throw new InvalidOperationException(
                    "Email already exists.");
            }

            if (await _context.Users
                .AnyAsync(x => x.Mobile == request.Mobile))
            {
                throw new InvalidOperationException(
                    "Mobile already exists.");
            }

             if (await _context.Users
                .AnyAsync(x => x.UserName == request.UserName))
            {
                throw new InvalidOperationException(
                    "Username already exists.");
            }
            return new ValidationResponse(true, string.Empty);
        }
        catch (Exception ex)
        {
            return new ValidationResponse(false, ex.Message);
        }
    }
}