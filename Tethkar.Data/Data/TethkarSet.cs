using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Models;

namespace Tethkar.Data.Data;

public partial class AppDbContext
{
     public DbSet<City> Cities { get; set; }
     public DbSet<Category> Categories { get; set; }
     public DbSet<Event> Events { get; set; }
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<TicketType> TicketTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
}