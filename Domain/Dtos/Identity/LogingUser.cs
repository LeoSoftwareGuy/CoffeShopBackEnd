using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Identity
{
    public class LoggingUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
