using Application.Common.Constants;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Users.Commands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private readonly IStringLocalizer L;
    public CreateUserCommandValidator(IStringLocalizer l)
    {
        L = l;
        RuleFor(v => v.Name)
            .NotNull().WithMessage(_ => L[AppResources.NameShouldNotBeEmpty])
            .NotEmpty().WithMessage(_ => L[AppResources.NameShouldNotBeEmpty])
            .MaximumLength(250);

        RuleFor(v => v.Surname)
            .NotEmpty().WithMessage(_ => L[AppResources.SurnameShouldNotBeEmpty])
            .MaximumLength(250);
    }
}
