using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Web.HttpMethods;

internal sealed class HttpFavoriteAttribute : HttpMethodAttribute
{
    private static readonly IEnumerable<string> SupportedMethods =
    [
        "FAVORITE"
    ];
    
    public HttpFavoriteAttribute() : base(SupportedMethods)
    {
    }

    public HttpFavoriteAttribute([StringSyntax("Route")] string? template) : base(SupportedMethods, template)
    {
        ArgumentNullException.ThrowIfNull(template, nameof (template));
    }
}