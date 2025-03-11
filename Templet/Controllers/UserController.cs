using Templet.Core.Features.Users.Command.Model;
using Templet.Core.Features.Users.Queries.Model;
using Templet.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using Templet.API.Base;

namespace Templet.Api.Controllers;

public class UserController : AppBaseController
{

    //POST Create User
    [HttpPost(Router.UserRouting.Create)]
    public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
    //GET Pagination
    [HttpGet(Router.UserRouting.Paginated)]
    public async Task<IActionResult> GetUserAsPaginated([FromQuery] GetUserPaginatedListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
    //GET UserById
    [HttpGet(Router.UserRouting.GetById)]
    public async Task<IActionResult> GetUserById([FromRoute] string id)
    {
        var request = new GetUserByIdQuery() { UserId = id };
        var response = await Mediator.Send(request);
        return Ok(response);
    }
    //PUT EditUser
    [HttpPut(Router.UserRouting.Edit)]
    public async Task<IActionResult> EditUser([FromBody] EditUserCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }

    //Delete DeleteAppUser
    [HttpDelete(Router.UserRouting.Delete)]
    public async Task<IActionResult> DeleteUser([FromRoute] string id)
    {
        var request = new DeleteUserCommand { Id = id };
        var response = await Mediator.Send(request);
        return NewResult(response);
    }

    //PUT ChangeUserPassword
    [HttpPut(Router.UserRouting.ChangePassword)]
    public async Task<IActionResult> ChangePasswordUser([FromBody] ChangeUserPasswordCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
}
