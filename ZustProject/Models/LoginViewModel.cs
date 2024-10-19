using System.ComponentModel.DataAnnotations;

namespace ZustProject.Models
{
    public class LoginViewModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
