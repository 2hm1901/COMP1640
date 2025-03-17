using Common.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;
public static class DependencyInjection
{
    public static IServiceCollection AddBLL(this IServiceCollection services)
    {
        services.AddScoped<StudentService>();
        services.AddScoped<InteractionService>();
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}