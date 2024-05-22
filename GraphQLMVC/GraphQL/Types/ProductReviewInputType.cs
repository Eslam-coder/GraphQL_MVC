using GraphQL.Types;

namespace GraphQLMVC.GraphQL.Types
{
    public class ProductReviewInputType : InputObjectGraphType
    {
        public ProductReviewInputType()
        {
            Name = "ProductReviewInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<StringGraphType>("review");
            Field<IntGraphType>("productId");
            //Field<NonNullGraphType<IntGraphType>>("productId");
        }
    }
}
