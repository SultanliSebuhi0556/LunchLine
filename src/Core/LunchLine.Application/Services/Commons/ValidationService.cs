using FluentValidation;
using FluentValidation.Results;
using LunchLine.Application.Abstractions.Commons;
using Microsoft.Extensions.DependencyInjection;

namespace LunchLine.Application.Services.Commons;

public class ValidationService(IServiceProvider _serviceProvider) : IValidationService
{
    public async Task<IEnumerable<ValidationFailure>> ValidateAsync<T>(T dto)
    {
        var validator = _serviceProvider.GetService<IValidator<T>>();
        if (validator != null)
        {
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid) throw new ValidationException(result.Errors);
        }
        return [];
    }
}