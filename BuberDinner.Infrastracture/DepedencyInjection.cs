using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastracture.Authentication;
using BuberDinner.Infrastracture.Persistence;
using BuberDinner.Infrastracture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastracture;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastracture(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerators>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
