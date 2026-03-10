using LunchLine.Application.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace LunchLine.Application;

public static class ServiceRegistrationApplication
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMapperProfiles();
        return services;
    }

    public static IServiceCollection AddMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(x => x.AddMaps(typeof(EmployeeProfile).Assembly));
        return services;
    }
}