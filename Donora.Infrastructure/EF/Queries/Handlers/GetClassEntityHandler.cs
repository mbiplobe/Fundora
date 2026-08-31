using Microsoft.EntityFrameworkCore;
using Donora.Infrastructure.EF.Contexts;
using Donora.Shared.Abstractions.Queries;

namespace Donora.Infrastructure.EF.Queries.Handlers;

internal sealed class GetClassEntityHandler : IQueryHandler<GetClasses, IEnumerable<ClassEntityDto>>
{
    private readonly ReadDbContext _context;

    public GetClassEntityHandler(ReadDbContext context)
        => _context = context;

    public async Task<IEnumerable<ClassEntityDto>> HandleAsync(GetClasses query)
    {
        var result = await _context.Classes
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();

        return result;
    }
}
   