using Templet.Core.Features.Users.Command.Model;
using Templet.Service.Abstract;
using FluentValidation;

namespace Templet.Core.Features.Users.Command.Validator;

public class EditUserCommandValidator:AbstractValidator<EditUserCommand>
{
    private readonly IAppUserService _appUserService;

    public EditUserCommandValidator(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }

    public void EditUserValidator()
    {
        RuleFor(e => e.Email).MustAsync(async (model, Key, CancellationToken) =>
            !await _appUserService.IsEmailExistExcludeSelf(model.Id, model.Email)).WithMessage("IsExist");
    }
}