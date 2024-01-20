using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte[]? Picture { get; set; }
    }
}
