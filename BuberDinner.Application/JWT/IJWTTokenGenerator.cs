using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Application.Services.JWT
{
    public interface IJWTTokenGenerator
    {
        Task<string> GenerateToken(User user);
    }
}
