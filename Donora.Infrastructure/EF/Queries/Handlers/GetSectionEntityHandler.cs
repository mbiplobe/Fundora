using Microsoft.EntityFrameworkCore;
using Donora.Infrastructure.EF.Contexts;
using Donora.Infrastructure.EF.Queries;
using Donora.Shared.Abstractions.Queries;

internal sealed class GetSectionEntityHandler : IQueryHandler<GetSections, IEnumerable<SectionEntityDto>>
{
    private readonly ReadDbContext _context;

    public GetSectionEntityHandler(ReadDbContext context)
        => _context = context;

    public async Task<IEnumerable<SectionEntityDto>> HandleAsync(GetSections query)
    {
        var result = await _context.Sections
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();

        return result;
    }
}
   