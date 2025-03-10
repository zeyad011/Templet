using Templet.Core.Bases;
using Templet.Core.Features.Users.Queries.Model;
using Templet.Core.Features.Users.Queries.Response;
using Templet.Core.Wrappers;
using Templet.Data.Entities.HR.Identity;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AGECS_ERP.Core.Features.Users.Queries.Handler;

public class AppUserQueryHandler : ResponseHandler,
    IRequestHandler<GetUserPaginatedListQuery, PaginatedResult<GetUserPaginatedListResponse>>,
    IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
{
    private readonly IMapper _mapper;
    private readonly UserManager<Employee> _userManager;

    public AppUserQueryHandler(IMapper mapper, UserManager<Employee> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<PaginatedResult<GetUserPaginatedListResponse>> Handle(GetUserPaginatedListQuery request, CancellationToken cancellationToken)
    {
        var users = _userManager.Users.AsQueryable();
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            users = users.Where(u => u.UserName.Contains(request.SearchTerm) ||
                          u.Email.Contains(request.SearchTerm) ||
                          (u.FirstName + " " + u.LastName).Contains(request.SearchTerm));

        }
        var paginatedList = await _mapper.ProjectTo<GetUserPaginatedListResponse>(users)
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return paginatedList;
    }

    public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        //check user exist or no 
        var user = await _userManager.Users
       .Include(e => e.Department)
       .FirstOrDefaultAsync(e => e.Id == request.UserId);

        if (user is null) return NotFound<GetUserByIdResponse>();
        //make mapping
        var userMapper = _mapper.Map<GetUserByIdResponse>(user);
        return Success(userMapper);
    }
}