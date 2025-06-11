

namespace Domain.Interface.Repository
{
    public interface IGenerciRepository<T> where T : class
    {
        T GetbyIdAsync(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
        

    }
}
