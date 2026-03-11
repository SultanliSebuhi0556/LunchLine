using FluentValidation;
using LunchLine.Application.DTOs.CommonDTOs;

namespace LunchLine.Application.Validations.CommonValidations;

public class GetListDTOValidation : AbstractValidator<GetListDTO>
{
    public GetListDTOValidation()
    {
        RuleFor(x => x.Skip).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Take).GreaterThan(0);
    }
}
