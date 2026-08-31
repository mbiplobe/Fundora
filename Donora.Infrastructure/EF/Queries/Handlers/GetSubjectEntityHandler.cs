using Microsoft.EntityFrameworkCore;
using Donora.Infrastructure.EF.Contexts;
using Donora.Shared.Abstractions.Queries;

namespace Donora.Infrastructure.EF.Queries.Handlers;

internal sealed class GetSubjectEntityHandler
    : IQueryHandler<GetAllSubjects, IEnumerable<SubjectEntityDto>>
{
    private readonly ReadDbContext _context;

    public GetSubjectEntityHandler(ReadDbContext context)
        => _context = context;

    public async Task<IEnumerable<SubjectEntityDto>> HandleAsync(GetAllSubjects query)
    {
        var result = await _context.Subjects
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();

        return result;
    }
}