using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirbnbClone.Models.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Fullname { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
