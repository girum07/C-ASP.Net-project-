
using Domain.DataTransferObject.Request;

namespace Domain.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ITicketRepository TicketsRepository { get; }

        IEnumerable<object> GetTickets(GetTicketRequest request);
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveChanges();
        Task<bool> SaveChangesReturnBool();
    }
}