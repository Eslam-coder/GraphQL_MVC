using GraphQLMVC.Data.Entities;

namespace GraphQLMVC.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProudcts();
    }
}
