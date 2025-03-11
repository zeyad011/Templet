using Templet.Core.Bases;
using Templet.Data.DTOs;
using MediatR;

namespace Templet.Core.Features.Authorization.Command.Model;

public class UpdateUserRolesCommand : IRequest<Response<string>>
{
    public string UserId { get; set; }
    public List<UserRoles> Roles { get; set; } //dtos
}
