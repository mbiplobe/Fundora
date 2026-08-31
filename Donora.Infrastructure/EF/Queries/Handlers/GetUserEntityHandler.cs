using Donora.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Donora.Shared.Abstractions.Queries;

namespace Donora.Infrastructure.EF.Queries.Handlers;

internal sealed class GetUserEntityHandler : IQueryHandler<GetUserEntity, UserEntityDto>
{
    private readonly ReadDbContext _context;

    public GetUserEntityHandler(ReadDbContext context)
        => _context = context;

    public async Task<UserEntityDto> HandleAsync(GetUserEntity query)
    {
        var result = await _context.Users
            .AsNoTracking()
            .Where(x => x.ID == query.Id)
            .FirstOrDefaultAsync();

        if (result is null)
            throw new KeyNotFoundException($"User not found: {query.Id}");

        return result.AsDto();
    }
}