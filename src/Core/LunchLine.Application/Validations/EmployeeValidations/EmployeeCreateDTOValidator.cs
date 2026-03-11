using FluentValidation;
using LunchLine.Application.DTOs.EmployeeDTOs;

namespace LunchLine.Application.Validations.EmployeeValidations;

public class EmployeeCreateDTOValidator : AbstractValidator<EmployeeCreateDTO>
{
    public EmployeeCreateDTOValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
        RuleFor(x => x.PositionId).NotEmpty();
        RuleFor(x => x.Salary).GreaterThan(0);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.PhoneNumber).NotEmpty()
            .Matches(@"^\+994(50|51|55|70|77|99|10)\d{7}$")
            .WithMessage("Invalid Azerbaijan phone format.");
    }
}
