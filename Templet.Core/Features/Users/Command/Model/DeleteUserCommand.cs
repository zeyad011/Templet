using Templet.Core.Bases;
using MediatR;

namespace Templet.Core.Features.Users.Command.Model;

public class DeleteUserCommand : IRequest<Response<string>>
{
    public string Id { get; set; }
}