using Templet.API.Base;
using Templet.Core.Features.Authorization.Command.Model;
using Templet.Core.Features.Authorization.Queries.Model;
using Templet.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Templet.API.Controllers;
[Authorize]
public class AuthorizationController : AppBaseController
{

    [HttpPost(Router.AuthorizationRouting.CreateRole)]
    public async Task<IActionResult> CreateRoles([FromForm] AddRoleCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
    [HttpGet(Router.AuthorizationRouting.MangeUserRoles)]
    public async Task<IActionResult> MangeUserRoles([FromRoute] string userId)
    {
        var request = new GetUserRolesByIdQuery(userId);
        var response = await Mediator.Send(request);
        return NewResult(response);
    }
    [HttpGet(Router.AuthorizationRouting.GetRolesList)]
    public async Task<IActionResult> GetRoles()
    {
        var request = new GetRolesListQuery();
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpGet(Router.AuthorizationRouting.GetClimsList)]
    public async Task<IActionResult> GetCliams()
    {
        var request = new GetClaimsListQuery();
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    [HttpGet(Router.AuthorizationRouting.MangeUserClaims)]
    public async Task<IActionResult> MangeUserClaims([FromRoute] string userId)
    {
        var request = new GetUserClaimsByIdQuery(userId);
        var response = await Mediator.Send(request);
        return NewResult(response);
    }
    [HttpPut(Router.AuthorizationRouting.UpdateRole)]
    public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut(Router.AuthorizationRouting.UpdateClaims)]
    public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
}