
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
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new InvalidOperationException("Email is required.");
            }

            var email = request.Email.Trim().ToLowerInvariant();
            var mobile = request.Mobile.Trim();

            if (await _context.Users
           .AnyAsync(x => x.Email == email))
            {
                throw new InvalidOperationException(
                    "Email already exists.");
            }

            if (await _context.Users
                .AnyAsync(x => x.Mobile == mobile))
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