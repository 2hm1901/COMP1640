using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;
public static class DependencyInjection
{
    public static IServiceCollection AddBLL(this IServiceCollection services)
    {
        services.AddScoped<StudentService>();
        services.AddScoped<UserService>();
        return services;
    }
}