using Templet.API.Base;
using Templet.Core.Features.Authentication.Model;
using Templet.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Templet.API.Controllers;

public class AuthenticationController : AppBaseController
{

    [HttpPost(Router.AuthenticationRouting.SginIn)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }

}