using Templet.Core.Bases;
using MediatR;

namespace Templet.Core.Features.Users.Command.Model;

public class ChangeUserPasswordCommand : IRequest<Response<string>>
{
    public string Id { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}