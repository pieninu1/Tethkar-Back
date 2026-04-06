using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Models;

namespace Tethkar.Data.Data;
public partial class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public const string DBConnectionString = ConnectionString.TestString;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(DBConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");

        // TicketType configuration
        builder.Entity<TicketType>()
            .Property(t => t.Price)
            .HasColumnType("decimal(18,2)");

        // Order configuration
        builder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasColumnType("decimal(18,2)");

        // OrderItem configuration
        builder.Entity<OrderItem>()
            .Property(oi => oi.UnitPrice)
            .HasColumnType("decimal(18,2)");

        builder.Entity<Payment>()
            .Property(p => p.Amount)
            .HasColumnType("decimal(18,2)");

        builder.Entity<Ticket>()
            .HasOne(t => t.OrderItem)
            .WithMany(oi => oi.Tickets)
            .HasForeignKey(t => t.OrderItemId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Ticket>()
            .HasOne(t => t.TicketType)
            .WithMany(tt => tt.Tickets)
            .HasForeignKey(t => t.TicketTypeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Ticket>()
            .HasOne(t => t.Buyer)
            .WithMany()
            .HasForeignKey(t => t.BuyerUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Order>()
            .HasOne(o => o.Buyer)
            .WithMany()
            .HasForeignKey(o => o.BuyerUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Event>()
            .HasOne(e => e.City)
            .WithMany(c => c.Events)
            .HasForeignKey(e => e.CityId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Event>()
            .HasOne(e => e.Organizer)
            .WithMany()
            .HasForeignKey(e => e.OrganizerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}