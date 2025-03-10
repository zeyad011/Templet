using Templet.Core.Bases;
using Templet.Core.Features.Users.Queries.Response;
using MediatR;

namespace Templet.Core.Features.Users.Queries.Model;

public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
{
    public string UserId { get; set; }
}