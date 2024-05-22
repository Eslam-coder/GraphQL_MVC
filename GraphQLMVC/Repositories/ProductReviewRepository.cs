using GraphQLMVC.Data.Entities;
using GraphQLMVC.Data;

namespace GraphQLMVC.Repositories
{
    public class ProductReviewRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductReviewRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductReview> GetAllProudctReviews()
        {
            return _dbContext.ProductReviews;
        }

        public IEnumerable<ProductReview> GetProudctReviews(int productId)
        {
            return _dbContext.ProductReviews.Where(productReview => productReview.ProductId == productId);
        }

        public async Task<ILookup<int, ProductReview>> GetForProudcts(IEnumerable<int> productsIds)
        {
            var reviews =   _dbContext.ProductReviews
                            .Where(productReview => productsIds.Contains(productReview.ProductId));
            return reviews.ToLookup(r => r.ProductId);
        }

        public async Task<ProductReview> AddReview(ProductReview productReview)
        {
            _dbContext.ProductReviews.Add(productReview);
            await _dbContext.SaveChangesAsync();   
            return productReview;
        }
    }
}
