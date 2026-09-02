using Donora.Shared.Abstractions.Queries;

namespace Donora.Infrastructure.EF.Queries;

public sealed record GetUsers: IQuery<IEnumerable<UserEntityDto>>;