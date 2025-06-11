
namespace Domain.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenerciRepository<TEntity>Repository<TEntity>() where TEntity : class;
        Task<int> SaveChanges();
        Task<bool> SaveChangesReturnBool();
    }
}
