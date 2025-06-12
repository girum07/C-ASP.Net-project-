using Domain.DataTransferObject.Request;
using Domain.DataTransferObject.Response;
using Domain.Entity;

using Domain.Interface.Repository;
using Infrastructure.Repository;

namespace Infrastructure.Service
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public GetTicketsResponse FindTicket(int ticketId)
        {
            var result = unitOfWork.Repository<Ticket>().GetbyIdAsync(ticketId);
            if (result == null) return null;

            return new GetTicketsResponse
            {
                TicketId = result.TicketId,
                Summary = result.Summary,
                Description = result.Description,
                ProductId = result.ProductId,
                PriorityId = result.PriorityId,
                CategoryId = result.Category,
                Status = result.Status,
                RaisedBy = result.RaisedbyUser?.Email,
                CreatedDate = result.RaisedDate,
                ExpectedDate = result.ExpectedDate
            };
        }

        public List<GetTicketsResponse> GetTickets(GetTicketRequest request)
        {

            var result = unitOfWork.TicketsRepository.GetTickets(request);

            return result.Select(static x => new GetTicketsResponse
            { 
                TicketId = x.TicketId,
                Summary = x.Summary,
                Product = x.Product?.ProductName,
               // Category = x.Category?.CategoryName,
                Priority = x.Priority?.PriorityName,
                Status = x.Status,
                RaisedBy = x.RaisedbyUser?.Email,
                CreatedDate = x.RaisedDate,
                ExpectedDate = x.ExpectedDate
            }).ToList();
        }
    }
}
