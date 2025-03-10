using Templet.Core.Features.Users.Queries.Response;
using Templet.Data.Entities.HR.Identity;

namespace Templet.Core.Mapping.Users;

public partial class UserProfile
{
    public void Mapping_GetUserByIdQuery()
    {
        CreateMap<Employee, GetUserByIdResponse>()
            .ForMember(d => d.DepartmentId, opt => opt.MapFrom(s => s.DepartmentId))
            .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Department.DepartmentName));
    }
}