namespace Tethkar.Data.DTOs
{
    public class UserProfileDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; } 

        public string? Nationality { get; set; }
        public string? Residence { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}