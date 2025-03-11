using Templet.Core.Bases;
using Templet.Data.DTOs;
using MediatR;


namespace Templet.Core.Features.Authorization.Queries.Model;

public class GetUserRolesByIdQuery(string userId) : IRequest<Response<GetUserRolesResponse>>
{
    public string UserId { get; set; } = userId;
}