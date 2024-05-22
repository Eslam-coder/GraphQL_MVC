using GraphQL;
using GraphQL.Types;
using GraphQLMVC.Data.Entities;
using GraphQLMVC.GraphQL.Types;
using GraphQLMVC.Repositories;

namespace GraphQLMVC.GraphQL
{
    public class CarvedRockMutation : ObjectGraphType
    {
        public CarvedRockMutation(ProductReviewRepository productReviewRepository)
        {
            FieldAsync<ProductReviewType>(
                name: "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductReviewInputType>>
                    { Name = "review" }),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    return await productReviewRepository.AddReview(review);
                }
            );
        }
        
    }
}
