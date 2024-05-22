using GraphQL.Types;

namespace GraphQLMVC.GraphQL
{
    public class CarvedRockSchema : Schema
    {
        public CarvedRockSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<CarvedRockQuery>();
            Mutation = provider.GetRequiredService<CarvedRockMutation>();
        }
    }
}
