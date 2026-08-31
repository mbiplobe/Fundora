

using Microsoft.EntityFrameworkCore;
using Donora.Infrastructure.EF.Contexts;
using Donora.Infrastructure.EF.Models;
using Donora.Shared.Abstractions.Queries;

namespace Donora.Infrastructure.EF.Queries.Handlers;

internal sealed class SearchUserEntityHandler : IQueryHandler<SearchUserEntity, IEnumerable<UserEntityDto>>
{
    private readonly DbSet<UserReadModel> _UserEntities;

    public SearchUserEntityHandler(ReadDbContext context)
        => _UserEntities = context.Users;

    public async Task<IEnumerable<UserEntityDto>> HandleAsync(SearchUserEntity query)
    {
        var dbQuery = _UserEntities.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(query.SearchPhrase))
        {
            dbQuery = dbQuery.Where(x =>
        Microsoft.EntityFrameworkCore.EF.Functions.Like(
            (x.FirstName ?? "") + " " +
            (x.MiddleName ?? "") + " " +
            (x.LastName ?? ""),
            $"%{query.SearchPhrase}%"
        ));
        }

        return await dbQuery
            .Select(x => new UserEntityDto(
                x.ID,
                x.FirstName + " " + (x.MiddleName ?? "") + " " + (x.LastName ?? ""),
                x.Email,
                x.Mobile
            ))
            .ToListAsync();
    }

}

