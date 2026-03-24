using FluentValidation;
using LunchLine.Application.DTOs.MenuItemDTOs;

namespace LunchLine.Application.Validations.MenuItemValidations;

public class MenuItemUpdateDTOValidator : AbstractValidator<MenuItemUpdateDTO>
{
    public MenuItemUpdateDTOValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Type).NotNull();
        RuleFor(x => x.IsVIP).NotNull();
    }
}
