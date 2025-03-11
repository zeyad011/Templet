using Templet.Data.Entities.Identity;

namespace Templet.Service.Abstract;

public interface IAppUserService
{
    public Task<bool> IsEmailExistExcludeSelf(string id, string email);
    public Task<string> AddUserAsync(Employee user, string password);


}