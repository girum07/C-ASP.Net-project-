
using Domain.DataTransferObject.Request;
using Domain.DataTransferObject.Response;

namespace Domain.Interface.Repository
{
    public interface ITicketService
    {
        List<GetTicketsResponse> GetTickets(GetTicketRequest request);
        GetTicketsResponse FindTicket(int TicketId);
    }
}
