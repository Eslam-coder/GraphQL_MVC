using GraphQL.Types;

namespace GraphQLMVC.GraphQL.Types
{
    public class ProductTypeEnumType : EnumerationGraphType<Data.Entities.ProductType>
    {
        public ProductTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the product type object.";
        }
    }
}
