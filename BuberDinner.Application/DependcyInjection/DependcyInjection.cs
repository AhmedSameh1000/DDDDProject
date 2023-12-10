using System.Reflection;
using BuberDinner.Application.Bases;
using BuberDinner.Application.Services.JWT;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application.DependcyInjection
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddApplicationSerivces(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddMediatR(
                md => md.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())
            );

            services.AddScoped<IJWTTokenGenerator, JWTTokenGenerator>();

            // services.AddScoped<
            //     IPipelineBehavior<RegisterCommand, Response<AuthResult>>,
            //     ValidationBehaviors
            // >();

            // services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            //FluentValidation.AspNetCore



            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
