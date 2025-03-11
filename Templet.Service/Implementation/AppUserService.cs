using Templet.Data.Entities.Identity;
using Templet.Infrastructure.DbContext;
using Templet.Service.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Templet.Service.Implementation;

public class AppUserService : IAppUserService // Employee
{
    private readonly UserManager<Employee> _userManager;
    private readonly ApplicationDbContext _applicationDbContext;

    public AppUserService(UserManager<Employee> userManager,
                                      ApplicationDbContext applicationDBContext
                                      )
    {
        _userManager = userManager;
        _applicationDbContext = applicationDBContext;
    }

    public async Task<string> AddUserAsync(Employee user, string password)
    {
        var trans = await _applicationDbContext.Database.BeginTransactionAsync();
        try
        {
            //if Email is Exist
            var existUser = await _userManager.FindByEmailAsync(user.Email);
            //email is Exist
            if (existUser != null) return "EmailIsExist";

            //if username is Exist
            var userByUserName = await _userManager.FindByNameAsync(user.UserName);
            //username is Exist
            if (userByUserName != null) return "UserNameIsExist";
            //Create
            var createResult = await _userManager.CreateAsync(user, password);
            //Failed
            if (!createResult.Succeeded)
                return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());

            await _userManager.AddToRoleAsync(user, "User");

            //Send Confirm Email
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //var resquestAccessor = _httpContextAccessor.HttpContext.Request;
            //var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code });
            //var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";
            //$"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
            //message or body

            await trans.CommitAsync();
            return "Success";
        }
        catch (Exception ex)
        {
            await trans.RollbackAsync();
            return "Failed";
        }

    }

    public async Task<List<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
    {
        return await _userManager.Users
            .ToListAsync();

    }

    public async Task<bool> IsEmailExistExcludeSelf(string id, string email)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email & u.Id != id);
        return user != null;
    }
}