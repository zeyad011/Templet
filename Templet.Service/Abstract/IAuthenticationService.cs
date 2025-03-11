

using Templet.Data.Entities.Identity;
using Templet.Data.Helpers;

namespace Templet.Service.Abstract;

public interface IAuthenticationService
{
    public Task<JwtAuthResult> GenerateTokenAsync(Employee user);
    public Task<string> ConfirmEmail(string? userId, string? code);

}