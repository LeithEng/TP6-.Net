using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class LoginCredentials
    {
        [Required]
        public string? Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}