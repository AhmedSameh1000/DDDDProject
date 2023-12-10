using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Bases;
using BuberDinner.Application.Services.JWT;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Infrastructure.Constants;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler
        : ResponseHandler,
            IRequestHandler<RegisterCommand, Response<AuthResult>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJWTTokenGenerator _jWTTokenGenerator;
        private readonly IValidator<RegisterCommand> _validator;

        public RegisterCommandHandler(
            UserManager<User> userManager,
            IJWTTokenGenerator jWTTokenGenerator,
            IValidator<RegisterCommand> validator
        )
        {
            _userManager = userManager;
            _jWTTokenGenerator = jWTTokenGenerator;
            _validator = validator;
        }

        public async Task<Response<AuthResult>> Handle(
            RegisterCommand Command,
            CancellationToken cancellationToken
        )
        {
            var ValidationResult = await _validator.ValidateAsync(Command);

            if (!ValidationResult.IsValid)
            {
                return BadRequest<AuthResult>(
                    string.Join(",", ValidationResult.Errors.ConvertAll(c => c.ErrorMessage))
                );
            }
            if (await _userManager.FindByEmailAsync(Command.Email) is not null)
                return BadRequest<AuthResult>("Email is Already Regitsered");

            var User = new User()
            {
                UserName = Command.Email,
                Email = Command.Email,
                FirstName = Command.FirstName,
                LastName = Command.LastName
            };
            var Result = await _userManager.CreateAsync(User, Command.Password);

            if (!Result.Succeeded)
            {
                var Error = string.Empty;
                foreach (var error in Result.Errors)
                {
                    Error += $"{error.Description},";
                }
                return BadRequest<AuthResult>(Error);
            }

            await _userManager.AddToRoleAsync(User, Constants.UserRole);

            var result = new AuthResult
            {
                Email = User.Email,
                Roles = new List<string> { "User" },
                Token = await _jWTTokenGenerator.GenerateToken(User),
                Message = "User Registered Seccesfuly"
            };
            return Success(result);
        }
    }
}
