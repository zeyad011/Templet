using Templet.Core.Features.Authorization.Command.Model;
using Templet.Service.Abstract;
using FluentValidation;

namespace Templet.Core.Features.Authorization.Command.Validator;

public class UpdateUserRolesCommandValidator : AbstractValidator<UpdateUserRolesCommand>
{
    private readonly IAuthorizationService _authorizationService;

    public UpdateUserRolesCommandValidator(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
        ApplyUpdateUserRolesCommand();
    }

    public void ApplyUpdateUserRolesCommand()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId cannot be empty");
        RuleForEach(x => x.Roles)
            .ChildRules(role =>
            {
                role.RuleFor(r => r.RoleName)
                    .NotEmpty()
                    .WithMessage("RoleName cannot be empty")
                    .MustAsync(async (key, CancellationToken) => await _authorizationService.IsExistRoleByRoleName(key))
                    .WithMessage("Invalid role name provided");

                role.RuleFor(r => r.Id)
                    .NotEmpty()
                    .WithMessage("Id cannot be empty")
                    .MustAsync(async (key, CancellationToken) => await _authorizationService.IsExistRoleByRoleId(key))
                    .WithMessage("Invalid role Id provided");
            });
    }
}