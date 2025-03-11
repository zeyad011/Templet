using Templet.Core.Bases;
using Templet.Core.Features.Authorization.Queries.Model;
using Templet.Data.DTOs;
using Templet.Data.Entities.Identity;
using Templet.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Templet.Core.Features.Authorization.Queries.Handler;

public class AuthorizationQueryHandler : ResponseHandler
     , IRequestHandler<GetUserRolesByIdQuery, Response<GetUserRolesResponse>>,
    IRequestHandler<GetUserClaimsByIdQuery, Response<GetUserClaimsResponse>>,
    IRequestHandler<GetRolesListQuery, Response<List<GetRolesResponse>>>,
    IRequestHandler<GetClaimsListQuery, Response<List<GetClaimsResponse>>>
{
    private readonly UserManager<Employee> _userManager;
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationQueryHandler(UserManager<Employee> userManager, IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _authorizationService = authorizationService;
    }


    public async Task<Response<GetUserRolesResponse>> Handle(GetUserRolesByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) return NotFound<GetUserRolesResponse>();
        var roles = await _authorizationService.GetUserRolesDataAsync(user);
        var response = Success(roles);
        return response;
    }

    public async Task<Response<GetUserClaimsResponse>> Handle(GetUserClaimsByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) return NotFound<GetUserClaimsResponse>();
        var claims = await _authorizationService.GetUserClaimsDataAsync(user);
        var response = Success(claims);
        return response;
    }

    public async Task<Response<List<GetRolesResponse>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
    {
        var roles = await _authorizationService.GetRolesListAsync();
        var response = Success(roles);
        return response;
    }

    public async Task<Response<List<GetClaimsResponse>>> Handle(GetClaimsListQuery request, CancellationToken cancellationToken)
    {
        var claims = _authorizationService.GetClaimsListAsync();
        var response = Success(claims);
        return response;
    }
}