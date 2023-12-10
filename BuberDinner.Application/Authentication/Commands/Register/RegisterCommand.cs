using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Bases;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string FirstName, string LastName, string Email, string Password)
        : IRequest<Response<AuthResult>>;
}
