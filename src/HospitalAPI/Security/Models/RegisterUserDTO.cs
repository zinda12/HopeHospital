using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Security.Models
{
    public class RegisterUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [RegularExpression(@"^(\d{13})$", ErrorMessage = "The pin must be 13 digits long.")]
        public string Pin { get; set; }
        public List<AllergenDTO> Allergens { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public BloodType BloodType { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}
