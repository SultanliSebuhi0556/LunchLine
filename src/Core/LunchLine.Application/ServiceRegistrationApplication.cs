using FluentValidation;
using LunchLine.Application.MapperProfiles;
using LunchLine.Application.Validations.CommonValidations;
using Microsoft.Extensions.DependencyInjection;

namespace LunchLine.Application;

public static class ServiceRegistrationApplication
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMapperProfiles();
        services.AddValidations();
        return services;
    }

    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<GetListDTOValidation>();
        return services;
    }

    public static IServiceCollection AddMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(x => x.AddMaps(typeof(EmployeeProfiles).Assembly));
        return services;
    }
}