using AGECS_ERP.Core.Features.Users.Queries.Response;
using AGECS_ERP.Data.Entities.HR.Identity;

namespace AGECS_ERP.Core.Mapping.Users;

public partial class UserProfile
{
    public void Mapping_GetPaginatedListQueryMapping()
    {
        CreateMap<Employee, GetUserPaginatedListResponse>()
            .ForMember(d => d.DepartmentId, opt => opt.MapFrom(s => s.DepartmentId))
            .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Department.DepartmentName));
    }
}