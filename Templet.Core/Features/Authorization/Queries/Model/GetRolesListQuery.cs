using Templet.Core.Bases;
using Templet.Data.DTOs;
using MediatR;

namespace Templet.Core.Features.Authorization.Queries.Model
{
    public class GetRolesListQuery : IRequest<Response<List<GetRolesResponse>>>
    {

    }
}
