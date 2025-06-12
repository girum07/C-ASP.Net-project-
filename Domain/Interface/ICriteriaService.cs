

using Domain.Entity;

namespace Domain.Interface
{
    public interface ICriteriaService
    {
        List<Priority> GetPriorityList();
        List<Category> GetCategoryList();
        List<Product> GetProductList();
        List<string> GetTicketStatusList();
    }
}
