using Domain.DataTransferObject.Request;
using Domain.Interface.Repository;
using infrastructure.Data;
using System.Collections;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBcontext _context;
        private readonly ITicketRepository _ticketRepository;
        private Hashtable _repositories;

        public UnitOfWork(AppDBcontext context, ITicketRepository ticketRepository)
        {
            _context = context;
            _ticketRepository = ticketRepository;
        }

        public ITicketRepository TicketsRepository => _ticketRepository;

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesReturnBool()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}