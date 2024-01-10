using Microsoft.AspNetCore.Identity;

namespace MVC_Core.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte[]? Picture { get; set; }
    }
}
