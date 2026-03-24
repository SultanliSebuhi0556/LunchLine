using FluentValidation;
using LunchLine.Application.DTOs.OrderItemDTOs;

namespace LunchLine.Application.Validations.OrderItemValidations;

public class OrderItemCreateDTOValidator : AbstractValidator<OrderItemCreateDTO>
{
    public OrderItemCreateDTOValidator()
    {
        RuleFor(x => x.MenuItemId).NotEmpty();
        RuleFor(x => x.Quantity).NotEmpty();
    }
}