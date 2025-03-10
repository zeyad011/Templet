using Templet.Core.Features.Users.Command.Model;
using FluentValidation;

namespace Templet.Core.Features.Users.Command.Validator;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{

    public AddUserCommandValidator()
    {
        ApplyAddUserValidator();
    }

    private void ApplyAddUserValidator()
    {
        RuleFor(us => us.Username)
            .NotEmpty().WithMessage("NotEmpty");
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("NotEmpty");
        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("NotEmpty");
        RuleFor(p => p.PhoneNumber)
            .NotEmpty().WithMessage("NotEmpty");

    }

}