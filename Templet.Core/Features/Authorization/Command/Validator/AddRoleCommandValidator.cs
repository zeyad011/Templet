using Templet.Core.Features.Authorization.Command.Model;
using Templet.Service.Abstract;
using FluentValidation;

namespace Templet.Core.Features.Authorization.Command.Validator;

public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{
    private readonly IAuthorizationService _authorizationService;

    public AddRoleCommandValidator(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
        ApplyValidation();
        ApplyValidationFailure();
    }

    private void ApplyValidation()
    {
        RuleFor(n => n.RoleName)
            .NotEmpty()
            .WithMessage("NotEmpty");
    }

    private void ApplyValidationFailure()
    {
        RuleFor(n => n.RoleName)
            .MustAsync(async (key, cancellationtoken) => !await _authorizationService.IsExistRoleByRoleName(key))
            .WithMessage("RoleIsExist");
    }
}