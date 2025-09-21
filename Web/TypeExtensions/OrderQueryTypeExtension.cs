using Web.ObjectTypes;
using Web.Resolvers;

namespace Web.TypeExtensions;

internal sealed class OrderQueryTypeExtension : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor
            .Field("orders")
            .Description("Return list of orders")
            .ResolveWith<OrderResolver>(static resolver => resolver.GetAsync(null!));
    }
}