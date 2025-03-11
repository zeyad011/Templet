
using Templet.Core.Bases;
using Templet.Data.DTOs;
using MediatR;

namespace Templet.Core.Features.Authorization.Queries.Model;

public class GetUserClaimsByIdQuery(string userId) : IRequest<Response<GetUserClaimsResponse>>
{
    public string UserId { get; set; } = userId;
}