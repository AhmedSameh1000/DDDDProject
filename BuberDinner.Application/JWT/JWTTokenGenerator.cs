using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Domain.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Application.Services.JWT
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
        private readonly JWTSettings _jWTSettings;
        private readonly UserManager<User> _userManager;

        public JWTTokenGenerator(IOptions<JWTSettings> options, UserManager<User> userManager)
        {
            _jWTSettings = options.Value;
            _userManager = userManager;
        }

        // dotnet remove [<PROJECT>] package <PACKAGE_NAME>

        public async Task<string> GenerateToken(User user)
        {
            var User = await _userManager.FindByIdAsync(user.Id);
            if (User is null)
                return null;

            var symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jWTSettings.secret)
            );

            var signingCredentials = new SigningCredentials(
                symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256
            );

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            }.Union(roleClaims);

            var SecurityToken = new JwtSecurityToken(
                issuer: _jWTSettings.issuer,
                audience: _jWTSettings.audience,
                expires: DateTime.Now.AddDays(_jWTSettings.expires),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(SecurityToken);
        }
    }
}
