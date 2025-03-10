using Templet.Core.Features.Users.Command.Model;
using Templet.Data.Entities.Identity;

namespace Templet.Core.Mapping.Users;

public partial class UserProfile
{
    public void Mapping_AddUserCommandMapping()
    {
        CreateMap<AddUserCommand, Employee>();
    }
}