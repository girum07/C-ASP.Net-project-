
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        internal readonly IdentityDbContext dBContext;
        public GenericRepository(IdentityDbContext dbContext)
        {
            this.dBContext = dbContext;
        }
        public T GetbyIdAsync(int id)
        {
            return dBContext.Set<T>().Find(id);
        }
        public List<T> GetAll()
        {
            return dBContext.Set<T>().ToList();
        }
        public void Add(T entity)
        {
            dBContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            dBContext.Set<T>().Attach(entity);
            dBContext.Entry(entity).State = EntityState.Modified;

        }
        public void Delete(T entity)
        {
            dBContext.Set<T>().Remove(entity);
        }
        public void SaveChanges()
        {
            dBContext.SaveChanges();

        }
    }
}
