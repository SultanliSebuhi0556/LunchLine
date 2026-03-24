using FluentValidation;
using LunchLine.Application.DTOs.OrderDTOs;
using LunchLine.Application.Validations.OrderItemValidations;

namespace LunchLine.Application.Validations.OrderValidations;

public class OrderCreateDTOValidator : AbstractValidator<OrderCreateDTO>
{
    public OrderCreateDTOValidator()
    {
        RuleFor(x => x.Details).MaximumLength(1024);
        RuleFor(x => x.Priority).NotNull();
        RuleFor(x => x.TableId).NotEmpty();
        RuleFor(x => x.EmployeeId).NotEmpty();
        RuleFor(x => x.OrderItems).NotEmpty();
        RuleForEach(x => x.OrderItems).SetValidator(new OrderItemCreateDTOValidator());
    }
}
