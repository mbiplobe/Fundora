
using Donora.Infrastructure.EF.Models;

internal static class Extensions
{
    public static UserEntityDto AsDto(this UserReadModel readModel)
        => new UserEntityDto(
            Id: readModel.Id,
            FullName: readModel.FirstName + " " + readModel.MiddleName + " " + readModel.LastName,
            Email: readModel.Email,
            Mobile: readModel.Mobile
        );

}

