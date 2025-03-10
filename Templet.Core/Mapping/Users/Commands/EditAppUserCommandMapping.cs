using Templet.Core.Features.Users.Command.Model;
using Templet.Data.Entities.HR.Identity;

namespace Templet.Core.Mapping.Users;

public partial class UserProfile
{
    public void Mapping_EditUserCommandMapping()
    {
        CreateMap<EditUserCommand, Employee>()
            .ForMember(i => i.Id, opt => opt.Ignore());
    }
}