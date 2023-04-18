using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Security.Models
{
    public class RegisterRequest
    {
        [Required]
        public RegisterUserDTO RegisterUser { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
