using System.ComponentModel.DataAnnotations;

namespace MBBE.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; } = String.Empty; 
        [Required]
        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
    }
}
