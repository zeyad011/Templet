using Templet.Core.Features.Users.Queries.Response;
using Templet.Core.Wrappers;
using MediatR;

namespace Templet.Core.Features.Users.Queries.Model;

public class GetUserPaginatedListQuery : IRequest<PaginatedResult<GetUserPaginatedListResponse>>
{
    public GetUserPaginatedListQuery()
    {

    }
    public GetUserPaginatedListQuery(int pageNumber, int pageSize, string? searchTerm = null)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchTerm = searchTerm;
    }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; }

}