using Templet.Core.Bases;
using MediatR;

namespace Templet.Core.Features.Authorization.Command.Model;

public class AddRoleCommand : IRequest<Response<string>>
{
    public string RoleName { get; set; }
}