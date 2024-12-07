using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class RegisterCredentials
    {
        [Required]
        public string? Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        public string? City { get; set; }
    }
}