using Domain.DataTransferObject.Request;
using Domain.Entity;
using Domain.Interface.Repository;
using infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDBcontext dbContext) : base(dbContext)
        {

        }

        public List<Ticket> GetTickets(GetTicketRequest request)

        {
            IQueryable<Ticket> query = dBContext.Set<Ticket>()
                .Include(x => x.Category)
                .Include(x => x.Priority)
                .Include(x => x.Product)
                .Include(x => x.RaisedbyUser)
                .Include(x => x.AssignedtoUser);

            if (request == null)
                return query.ToList();

            if (!string.IsNullOrEmpty(request.Summary))
            {
                query = query.Where(x => EF.Functions.Like(x.Summary, $"%{request.Summary}%"));
            }

            if (request.ProductId != null && request.ProductId.Any())
            {
                query = query.Where(x => request.ProductId.Contains(x.ProductId));
            }

            if (request.CategoryId != null && request.CategoryId.Any())
            {
                query = query.Where(x => request.CategoryId.Contains(x.Category));
            }

            if (request.PriorityId != null && request.PriorityId.Any())
            {
                query = query.Where(x => request.PriorityId.Contains(x.PriorityId));
            }

            if (request.Status != null && request.Status.Any())
            {
                query = query.Where(x => request.Status.Contains(x.Status));
            }

            if (request.RaisedBy != null && request.RaisedBy.Any())
            {
                query = query.Where(x => request.RaisedBy.Contains(x.RaisedBy));
            }

            return query.ToList();
        
        }
    
    }
}
