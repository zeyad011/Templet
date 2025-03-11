using Templet.Core.Features.Authentication.Model;
using FluentValidation;

namespace Templet.Core.Features.Authentication.Validator;

public class SiginValidator : AbstractValidator<SignInCommand>
{

    public SiginValidator()
    {
    }

    public void AddSigninValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("NotEmpty")
            .NotNull().WithMessage("NotNull");
        RuleFor(x => x.Password)
               .NotEmpty().WithMessage("NotEmpty")
            .NotNull().WithMessage("NotNull");
    }
}