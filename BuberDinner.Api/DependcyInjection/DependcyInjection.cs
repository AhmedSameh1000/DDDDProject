using System.Reflection;
using BuberDinner.Api.Common.Mapping;
using BuberDinner.Api.Filters;
using BuberDinner.Application.Services.JWT;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Api.DependcyInjection
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers(opt => opt.Filters.Add<ErrorHandlingFilterAtterbute>());
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMapping();

            return services;
        }
    }
}
