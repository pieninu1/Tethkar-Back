using System.ComponentModel.DataAnnotations.Schema;

namespace Tethkar.Data.Models;
public class OrderItem
{
    public long Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

     public long OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; }

    public long TicketId { get; set; }
    [ForeignKey(nameof(TicketId))]
    public Ticket? Ticket { get; set; }
}