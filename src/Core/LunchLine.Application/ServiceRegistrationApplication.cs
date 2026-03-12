using FluentValidation;
using LunchLine.Application.Abstractions.Commons;
using LunchLine.Application.MapperProfiles;
using LunchLine.Application.Services.Commons;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LunchLine.Application;

public static class ServiceRegistrationApplication
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddDependencies();
        services.AddValidations();
        services.AddMapperProfiles();
        return services;
    }

    private static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IValidationService, ValidationService>();
        return services;
    }

    private static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }

    private static IServiceCollection AddMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(x => x.AddMaps(typeof(EmployeeProfiles).Assembly));
        return services;
    }
}