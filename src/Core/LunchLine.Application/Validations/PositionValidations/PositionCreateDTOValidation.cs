using FluentValidation;
using LunchLine.Application.DTOs.PositionDTOs;

namespace LunchLine.Application.Validations.PositionValidations;

public class PositionCreateDTOValidation : AbstractValidator<PositionCreateDTO>
{
    public PositionCreateDTOValidation()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Role).NotNull();
    }
}