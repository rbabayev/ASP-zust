using System.ComponentModel.DataAnnotations;

namespace ZustProject.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }

    }
}
