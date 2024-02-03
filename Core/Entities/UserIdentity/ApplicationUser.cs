using Microsoft.AspNetCore.Identity;

namespace Core.Entities.UserIdentity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte[]? Picture { get; set; }
    }
}
