using Templet.Core.Bases;
using Templet.Core.Features.Authentication.Model;
using Templet.Core.Features.Authentication.Results;
using Templet.Data.Entities.Identity;
using Templet.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Templet.Core.Features.Authentication.Handler;

public class AuthenticationCommandHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<SignInResponse>>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly SignInManager<Employee> _signInManager;
    private readonly UserManager<Employee> _userManager;

    public AuthenticationCommandHandler(IAuthenticationService authenticationService, SignInManager<Employee> signInManager, UserManager<Employee> userManager)
    {
        _authenticationService = authenticationService;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<Response<SignInResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var result = new SignInResponse();

        var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.UserName == request.Username);

        if (user == null) return NotFound<SignInResponse>();

        // تحقق من صحة كلمة المرور
        var signinResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!signinResult.Succeeded) return BadRequest<SignInResponse>("PasswordInCorrect");

        var roles = await _userManager.GetRolesAsync(user);
        // توليد الـ AccessToken
        var jwtAuthResult = await _authenticationService.GenerateTokenAsync(user);
        if (jwtAuthResult == null) return BadRequest<SignInResponse>("Failed to generate token");

        // تعيين القيم إلى الكائن المسترجع
        result.JwtAuthResult = jwtAuthResult;
        result.UserName = user.UserName;
        result.UserId = user.Id;
        result.Email = user.Email;
        result.FullName = user.FullName;
        result.Roles = roles.Select(role => new UserRole { RoleName = role }).ToList();
        return Success(result);
    }



}