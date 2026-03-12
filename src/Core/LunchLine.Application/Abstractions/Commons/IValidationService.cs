using FluentValidation.Results;

namespace LunchLine.Application.Abstractions.Commons;

public interface IValidationService
{
    public Task<IEnumerable<ValidationFailure>> ValidateAsync<T>(T dto);
}