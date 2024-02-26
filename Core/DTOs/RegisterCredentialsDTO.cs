using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class RegisterCredentialsDTO
    {
        [Required(ErrorMessage ="Required 3 chars Min")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Required 3 chars Min")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required 3 chars Min")]
        [StringLength(15, MinimumLength = 3, ErrorMessage= "Required 3 chars Min")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "Password must containt 8 chars upper,lower,non-alph,and digits")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Password must containt 8 chars upper,lower,non-alph,and digits")]
        public string PhoneNumber { get; set; }
    }
}
