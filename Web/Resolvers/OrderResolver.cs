using HotChocolate.Resolvers;

namespace Web.Resolvers;

internal sealed class OrderResolver
{
    public string GetAsync(IResolverContext context)
    {
        return "Hello World";
    }
}