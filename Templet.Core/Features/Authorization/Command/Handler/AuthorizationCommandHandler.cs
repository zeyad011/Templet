using Templet.Core.Bases;
using Templet.Core.Features.Authorization.Command.Model;
using Templet.Data.DTOs;
using Templet.Service.Abstract;
using MediatR;

namespace Templet.Core.Features.Authorization.Command.Handler;

public class AuthorizationCommandHandler : ResponseHandler,
                               IRequestHandler<AddRoleCommand, Response<string>>,
                               IRequestHandler<UpdateUserRolesCommand, Response<string>>,
                               IRequestHandler<UpdateUserClaimsCommand, Response<string>>
{
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationCommandHandler(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _authorizationService.AddRoleAsync(request.RoleName);
        return result == "Added" ? Created("") : BadRequest<string>();
    }

    public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
    {
        var req = new GetUserRolesResponse();
        req.UserId = request.UserId;
        req.UserRoles = request.Roles;
        var result = await _authorizationService.UpdateUserRolesAsync(req);
        switch (result)
        {
            case "FailedToRemoveRoles": return BadRequest<string>("Failed to remove roles");
            case "FailedToAddRoles": return BadRequest<string>("Failed to add roles");
            default: return Updated<string>("Successfully updated roles");
        }
    }

    public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
    {
        var req = new UpdateUserClaimsRequest();
        req.UserId = request.UserId;
        req.UserClaims = request.UserClaims;
        var result = await _authorizationService.UpdateUserClaimsAsync(req);
        switch (result)
        {

            case "UserNotFound": return BadRequest<string>("User not found");
            case "FailedToRemoveClaims": return BadRequest<string>("Failed to remove claims");
            case "FailedToAddClaims": return BadRequest<string>("Failed to add claims");
            default: return Updated<string>("Successfully updated claims");
        }

    }
}