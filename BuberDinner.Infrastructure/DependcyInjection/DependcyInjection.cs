using System.Text;
using BuberDinner.Application.Services.JWT;
using BuberDinner.Domain.Models;
using BuberDinner.Infrastructure.Data;
using BuberDinner.Infrastructure.RepositoryPattern.IRepository;
using BuberDinner.Infrastructure.RepositoryPattern.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BuberDinner.Infrastructure.DependcyInjection
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddInfrastructureSerivces(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<ApplicationDbContext>(
                opt => opt.UseSqlServer(configuration.GetConnectionString("data"))
            );
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));
            services
                .AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredLength = 5;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequiredUniqueChars = 0;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var jwtSettings = services
                .BuildServiceProvider()
                .GetRequiredService<IOptions<JWTSettings>>()
                .Value;

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuers = new[] { jwtSettings.issuer },
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(jwtSettings.secret)
                        ),
                        ValidAudience = jwtSettings.audience,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo { Title = "BuberDinner Project", Version = "v1" }
                );
                c.EnableAnnotations();

                c.AddSecurityDefinition(
                    JwtBearerDefaults.AuthenticationScheme,
                    new OpenApiSecurityScheme
                    {
                        Description =
                            "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    }
                );

                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = JwtBearerDefaults.AuthenticationScheme
                                }
                            },
                            Array.Empty<string>()
                        }
                    }
                );
            });
            return services;
        }
    }
}
