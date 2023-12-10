using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Domain.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
