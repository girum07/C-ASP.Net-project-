using Domain.Entity;
using Domain.Interface;
using Infrastructure.Repository;


namespace Infrastructure.Service
{
    public class CriteriaService : ICriteriaService
    {
        private readonly UnitOfWork unitofwork;
        public CriteriaService(UnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;
        }

        public List<Category> GetCategoryList()
        {
            // Fix: Correctly invoke the Repository method and call ToList on the result
            return unitofwork.Repository<Category>().GetAll();
        }

        public List<Priority> GetPriorityList()
        {
            return unitofwork.Repository<Priority>().GetAll();
        }

        public List<Product> GetProductList()
        {
            return unitofwork.Repository<Product>().GetAll();
        }

        public List<string> GetTicketStatusList()
        {
            return new List<string>
            {
                "New",
                "Open",
                "Closed",
                
            };
        }
    }
}
