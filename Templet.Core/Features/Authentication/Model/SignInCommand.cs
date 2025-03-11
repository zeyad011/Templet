using Templet.Core.Bases;
using Templet.Core.Features.Authentication.Results;
using MediatR;

namespace Templet.Core.Features.Authentication.Model;

public class SignInCommand : IRequest<Response<SignInResponse>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}