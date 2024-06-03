using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{
    public class AppUser : IdentityUser
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = "";

        public string Address { get; set; } = "";
    }
}
