using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Application.Authentication.Common
{
    public class AuthResult
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }

        public string Message { get; set; }
    }
}
