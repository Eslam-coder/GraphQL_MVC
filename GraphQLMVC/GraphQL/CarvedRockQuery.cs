using GraphQL;
using GraphQL.Types;
using GraphQLMVC.Repositories;

namespace GraphQLMVC.GraphQL
{
    public class CarvedRockQuery : ObjectGraphType
    {
        public CarvedRockQuery(ProductRepository productRepository)
        {
            Field<ListGraphType<Types.ProductType>>(
                "products",
                resolve: context => productRepository.GetAllProudcts());

            Field<ListGraphType<Types.ProductType>>(
                name: "product",
                arguments: new QueryArguments
                           (new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id"}),
                resolve: context =>
                {
                    context.Errors.Add(new ExecutionError("Some error message"));
                    int id = context.GetArgument<int>("id");
                    return productRepository.GetProudct(id);
                });
        }
    }
}
