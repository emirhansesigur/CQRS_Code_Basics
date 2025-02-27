using Application.Common.Constants;
using Application.Users.Commands.CreateUser;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
{
    private readonly IStringLocalizer L;

    public UpdateUserCommandValidator(IStringLocalizer l)
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
