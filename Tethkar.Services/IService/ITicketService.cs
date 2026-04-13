using Tethkar.Data.DTOs;

namespace Tethkar.Services.IService
{
    public interface ITicketService
    {
        Task<string> BookTicketAsync(BookTicketDto model, string userId);
        Task<IEnumerable<MyTicketDto>> GetMyTicketsAsync(string userId);
    }
}