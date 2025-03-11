

using Templet.Data.DTOs;
using Templet.Data.Entities.Identity;

namespace Templet.Service.Abstract;

public interface IAuthorizationService
{
    public Task<string> AddRoleAsync(string roleName);
    public Task<bool> IsExistRoleByRoleName(string roleName);
    public Task<bool> IsExistRoleByRoleId(string roleId);
    public Task<List<GetRolesResponse>> GetRolesListAsync();
    public List<GetClaimsResponse> GetClaimsListAsync();
    public Task<GetUserRolesResponse> GetUserRolesDataAsync(Employee user);
    public Task<GetUserClaimsResponse> GetUserClaimsDataAsync(Employee user);
    public Task<string> UpdateUserRolesAsync(GetUserRolesResponse response);
    public Task<string> UpdateUserClaimsAsync(UpdateUserClaimsRequest request);
}