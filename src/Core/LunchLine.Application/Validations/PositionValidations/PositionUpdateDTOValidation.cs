using FluentValidation;
using LunchLine.Application.DTOs.PositionDTOs;

namespace LunchLine.Application.Validations.PositionValidations;

public class PositionUpdateDTOValidation : AbstractValidator<PositionUpdateDTO>
{
    public PositionUpdateDTOValidation()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Role).NotNull();
    }
}