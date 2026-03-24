using FluentValidation;
using LunchLine.Application.DTOs.TableDTOs;

namespace LunchLine.Application.Validations.TableValidations;

public class TableUpdateDTOValidator : AbstractValidator<TableUpdateDTO>
{
    public TableUpdateDTOValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Identifier).NotEmpty().MaximumLength(16);
        RuleFor(x => x.Section).NotEmpty().MaximumLength(16);
        RuleFor(x => x.SeatCount).NotEmpty().GreaterThan(0);
        RuleFor(x => x.IsVIP).NotNull();
        RuleFor(x => x.Direction).NotNull();
    }
}