using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Bases;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.LogIn
{
    public record LogInQuery(string Email, string Password) : IRequest<Response<AuthResult>>;
}
