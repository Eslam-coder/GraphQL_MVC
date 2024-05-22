using GraphQL.Types;
using GraphQLMVC.Data.Entities;

namespace GraphQLMVC.GraphQL.Types
{
    public class ProductReviewType : ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Field(p => p.Id);
            Field(p => p.Title);
            Field(p => p.Review);
        }
    }
}
