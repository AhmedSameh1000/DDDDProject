using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Bases;
using BuberDinner.Application.Services.JWT;
using BuberDinner.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Application.Authentication.Queries.LogIn
{
    public class LogInQueryHandler
        : ResponseHandler,
            IRequestHandler<LogInQuery, Response<AuthResult>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJWTTokenGenerator _jWTTokenGenerator;

        public LogInQueryHandler(
            UserManager<User> userManager,
            IJWTTokenGenerator jWTTokenGenerator
        )
        {
            _userManager = userManager;
            _jWTTokenGenerator = jWTTokenGenerator;
        }

        public async Task<Response<AuthResult>> Handle(
            LogInQuery query,
            CancellationToken cancellationToken
        )
        {
            var user = await _userManager.FindByEmailAsync(query.Email);

            if (user is null)
            {
                return NotFound<AuthResult>();
            }
            if (!await _userManager.CheckPasswordAsync(user, query.Password))
            {
                return BadRequest<AuthResult>("Email or Password is incorrect!");
            }

            var rolesList = await _userManager.GetRolesAsync(user);

            var AuthResult = new AuthResult
            {
                Email = user.Email!,
                Message = "LogIn Successfuly",
                Roles = rolesList.ToList(),
                Token = await _jWTTokenGenerator.GenerateToken(user)
            };

            return Success(AuthResult);
        }
    }
}
