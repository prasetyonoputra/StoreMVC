using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{
    public class RegisterVm
    {
        [Required]
        public string Name { get; set; } = "";

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Compare("Password", ErrorMessage = "Password not match!")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = "";

        [DataType(DataType.MultilineText)]
        public string Address { get; set; } = "";
    }
}
