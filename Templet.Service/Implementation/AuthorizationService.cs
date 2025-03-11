using Templet.Data.DTOs;
using Templet.Data.Entities.Identity;
using Templet.Data.Helpers;
using Templet.Service.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;

namespace Templet.Service.Implementation;

public class AuthorizationService : IAuthorizationService
{
    private readonly UserManager<Employee> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthorizationService(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<string> AddRoleAsync(string roleName)
    {
        var role = new IdentityRole(roleName);
        await _roleManager.CreateAsync(role);
        return "Added";
    }

    public async Task<bool> IsExistRoleByRoleId(string roleId)
    {
        var checkRole = await _roleManager.FindByIdAsync(roleId);
        if (checkRole == null) return false;
        return true;
    }

    public async Task<GetUserRolesResponse> GetUserRolesDataAsync(Employee user)
    {
        var roles = await _roleManager.Roles.ToListAsync();
        var userRoles = await _userManager.GetRolesAsync(user);
        var response = new GetUserRolesResponse();
        var userroles = new List<UserRoles>();
        response.UserId = user.Id;
        foreach (var role in roles)
        {
            var userrole = new UserRoles();
            userrole.Id = role.Id;
            userrole.RoleName = role.Name;
            if (userRoles.Contains(role.Name))
            {
                userrole.HasRole = true;
            }
            else
            {
                userrole.HasRole = false;
            }
            userroles.Add(userrole);
        }
        response.UserRoles = userroles;
        return response;

    }

    public async Task<GetUserClaimsResponse> GetUserClaimsDataAsync(Employee user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var response = new GetUserClaimsResponse();
        var userClaimsList = new List<UserClaims>();
        response.UserId = user.Id;
        foreach (var claim in ClaimsStore.Claims)
        {
            var userClaim = new UserClaims();
            userClaim.Type = claim.Type;
            if (userClaims.Any(x => x.Type == claim.Type))
            {
                userClaim.Value = true;
            }
            else
            {
                userClaim.Value = false;
            }
            userClaimsList.Add(userClaim);
        }
        response.UserClaims = userClaimsList;
        return response;
    }

    public async Task<string> UpdateUserRolesAsync(GetUserRolesResponse response)
    {
        var user = await _userManager.FindByIdAsync(response.UserId);
        var roles = await _userManager.GetRolesAsync(user!);
        var removeOldRoles = await _userManager.RemoveFromRolesAsync(user!, roles);
        if (!removeOldRoles.Succeeded) return "FailedToRemoveRoles";
        var selectedRole = response.UserRoles.Where(x => x.HasRole == true).Select(x => x.RoleName).ToList();
        var addNewRolesResult = await _userManager.AddToRolesAsync(user!, selectedRole);
        if (!addNewRolesResult.Succeeded) return "FailedToAddNewRoles";
        return "Success";
    }

    public async Task<bool> IsExistRoleByRoleName(string roleName)
    {
        return await _roleManager.RoleExistsAsync(roleName);
    }

    public async Task<string> UpdateUserClaimsAsync(UpdateUserClaimsRequest request)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) return "UserNotFound";
        var claims = await _userManager.GetClaimsAsync(user);
        var removeOldClaims = await _userManager.RemoveClaimsAsync(user, claims);
        if (!removeOldClaims.Succeeded) return "FailedToRemoveClaims";
        var selectedClaims = request.UserClaims.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));
        var addNewClaimsResult = await _userManager.AddClaimsAsync(user, selectedClaims);
        if (!addNewClaimsResult.Succeeded) return "FailedToAddNewClaims";
        return "Success";
    }

    public async Task<List<GetRolesResponse>> GetRolesListAsync()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        var rolesList = new List<GetRolesResponse>();
        foreach (var role in roles)
        {
            var response = new GetRolesResponse();
            response.Id = role.Id;
            response.RoleName = role.Name;
            rolesList.Add(response);
        }
        return rolesList;
    }
    public List<GetClaimsResponse> GetClaimsListAsync()
    {
        var claims = ClaimsStore.Claims;
        var claimsList = new List<GetClaimsResponse>();
        foreach (var claim in claims)
        {
            var response = new GetClaimsResponse();
            response.Value = claim.Value;
            response.ClaimsName = claim.Type;
            claimsList.Add(response);
        }
        return claimsList;
    }
}