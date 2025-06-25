using Domain.DataTransferObject.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChanges();
        Task<bool> SaveChangesReturnBool();
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        ITicketRepository TicketsRepository { get; }
    }
}