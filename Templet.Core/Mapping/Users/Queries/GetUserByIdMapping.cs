using Templet.Core.Features.Users.Queries.Response;
using Templet.Data.Entities.Identity;

namespace Templet.Core.Mapping.Users;

public partial class UserProfile
{
    public void Mapping_GetUserByIdQuery()
    {
        CreateMap<Employee, GetUserByIdResponse>();
    }
}