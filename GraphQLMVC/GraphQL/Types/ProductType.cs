using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLMVC.Data.Entities;
using GraphQLMVC.Repositories;
using System.Security.Claims;

namespace GraphQLMVC.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(
            ProductReviewRepository productReviewRepository,
            IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.Description);
            Field<ProductTypeEnumType>("Type", "The type of product");
            Field<ListGraphType<ProductReviewType>>(
            "reviews",
            resolve: context => 
            {
                //var user = (ClaimsPrincipal) context.UserContext;
                var loader = dataLoaderContextAccessor
                            .Context
                            .GetOrAddCollectionBatchLoader<int, ProductReview>
                            ("GetReviewsByProductId", productReviewRepository.GetForProudcts);
                return loader.LoadAsync(context.Source.Id);
            });
        }
    }
}
