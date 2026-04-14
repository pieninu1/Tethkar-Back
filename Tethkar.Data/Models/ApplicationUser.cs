using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Tethkar.Data.DTOs;
using Tethkar.Data.Enums;

namespace Tethkar.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public GenderEnum? Gender { get; set; }

        public string? Nationality { get; set; }

        public string? Residence { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<RefreshToken>? RefreshTokens { get; set; }
    }
}