using Templet.Core.Bases;
using Templet.Core.Features.Users.Command.Model;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Templet.Data.Entities.Identity;

namespace Templet.Core.Features.Users.Command.Handler;

public class AppUserHandler : ResponseHandler,
    IRequestHandler<AddUserCommand, Response<string>>,
    IRequestHandler<EditUserCommand, Response<string>>,
    IRequestHandler<DeleteUserCommand, Response<string>>,
    IRequestHandler<ChangeUserPasswordCommand, Response<string>>
{
    private readonly IMapper _mapper;
    private readonly UserManager<Employee> _userManager;

    public AppUserHandler(IMapper mapper, UserManager<Employee> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        // Check if email exists
        var checkEmailUser = await _userManager.FindByEmailAsync(request.Email);
        if (checkEmailUser != null) return BadRequest<string>("Email already exists.");

        // Check if username exists
        var checkUsername = await _userManager.FindByNameAsync(request.Username);
        if (checkUsername != null) return BadRequest<string>("Username already exists.");

        // Map request to Employee entity
        var user = _mapper.Map<Employee>(request);

        // Create user
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            // Return the first error message
            var error = result.Errors.FirstOrDefault()?.Description ?? "An error occurred while creating the user.";
            return BadRequest<string>(error);
        }

        return Created("User successfully created.");
    }

    public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        // Check if user ID exists
        var checkIdUser = await _userManager.FindByIdAsync(request.Id);
        if (checkIdUser == null) return NotFound<string>("User not found.");

        // Map updated properties
        _mapper.Map(request, checkIdUser);

        // Update user
        var result = await _userManager.UpdateAsync(checkIdUser);
        if (result.Succeeded) return Updated("User successfully updated.");

        // Return the first error message
        var error = result.Errors.FirstOrDefault()?.Description ?? "An error occurred while updating the user.";
        return BadRequest<string>(error);
    }

    public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        // Check if user exists
        var checkUser = await _userManager.Users.FirstOrDefaultAsync(i => i.Id.Equals(request.Id), cancellationToken: cancellationToken);
        if (checkUser == null) return NotFound<string>("User not found.");

        // Delete user
        await _userManager.DeleteAsync(checkUser);
        return Deleted<string>();
    }

    public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        // Find user
        var user = await _userManager.Users.FirstOrDefaultAsync(i => i.Id.Equals(request.Id), cancellationToken: cancellationToken);
        if (user == null) return NotFound<string>("User not found.");

        // Change password
        var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (result.Succeeded) return Updated("Password successfully changed.");

        // Return the first error message
        var error = result.Errors.FirstOrDefault()?.Description ?? "An error occurred while changing the password.";
        return BadRequest<string>(error);
    }
}
