using Templet.Core.Bases;
using Templet.Data.DTOs;
using MediatR;

namespace Templet.Core.Features.Authorization.Queries.Model
{
    public class GetClaimsListQuery : IRequest<Response<List<GetClaimsResponse>>>
    {

    }
}
