

using Donora.Infrastructure.EF.Contexts;
using Donora.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

internal sealed class GetUserEntityHandler
    : IQueryHandler<GetUserEntity, UserEntityDto>
{
    private readonly ReadDbContext _context;

    public GetUserEntityHandler(ReadDbContext context)
        => _context = context;

    public async Task<UserEntityDto> HandleAsync(GetUserEntity query)
    {
        var result = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.Id);

        if (result is null)
            throw new KeyNotFoundException(
                $"User not found: {query.Id}");

        return result.AsDto();
    }
}