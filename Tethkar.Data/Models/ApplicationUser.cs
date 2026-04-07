using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Tethkar.Data.DTOs;

namespace Tethkar.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        public List<RefreshToken>? RefreshTokens { get; set; }
    }
}