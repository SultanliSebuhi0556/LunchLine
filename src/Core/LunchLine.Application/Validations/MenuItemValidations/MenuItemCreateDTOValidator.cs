using FluentValidation;
using LunchLine.Application.DTOs.MenuItemDTOs;

namespace LunchLine.Application.Validations.MenuItemValidations
{
    internal class MenuItemCreateDTOValidator : AbstractValidator<MenuItemCreateDTO>
    {
        public MenuItemCreateDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(64);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Type).NotNull();
            RuleFor(x => x.IsVIP).NotNull();
        }
    }
}
