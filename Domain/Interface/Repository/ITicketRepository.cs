
using Domain.DataTransferObject.Request;
using Domain.Entity;

namespace Domain.Interface.Repository
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        List<Ticket> GetTickets(GetTicketRequest request);
    } 
}
