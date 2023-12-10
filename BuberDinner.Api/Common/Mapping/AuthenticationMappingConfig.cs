using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.LogIn;
using Mapster;
using Microsoft.AspNetCore.Identity.Data;

namespace BuberDinner.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LogInQuery>().Map(dest => dest, src => src);

            config.NewConfig<RegisterRequest, RegisterCommand>().Map(dest => dest, src => src);
        }
    }
}
