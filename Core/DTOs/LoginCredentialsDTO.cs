using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class LoginCredentialsDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "Password must containt 8 chars upper,lower,non-alph,and digits")]
        public string Password { get; set; }
    }
}
