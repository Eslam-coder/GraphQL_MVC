using GraphQLMVC.Data.Entities;
using GraphQLMVC.Data;

namespace GraphQLMVC.Repositories
{
    public class ProductRepository //: IProductRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProudcts()
        {
            return _dbContext.Products;
        }

        public Product GetProudct(int id)
        {
            return _dbContext.Products.Find(id);
        }
    }
}
