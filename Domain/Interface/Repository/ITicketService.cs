using Domain.DataTransferObject.Request;
using Domain.DataTransferObject.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface ITicketService
    {
        Task<GetTicketsResponse> FindTicket(int ticketId);
        List<GetTicketsResponse> GetTickets(GetTicketRequest request);
    }
}
