using Microsoft.Extensions.Logging;
using System.Net.Sockets;

namespace Tethkar.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Event> OrganizedEvents { get; set; } = new List<Event>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}