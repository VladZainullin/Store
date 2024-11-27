using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Web.HttpMethods;

internal sealed class HttpUnFavoriteAttribute : HttpMethodAttribute
{
    private static readonly IEnumerable<string> SupportedMethods =
    [
        "UNFAVORITE"
    ];
    
    public HttpUnFavoriteAttribute() : base(SupportedMethods)
    {
    }

    public HttpUnFavoriteAttribute([StringSyntax("Route")] string? template) : base(SupportedMethods, template)
    {
        ArgumentNullException.ThrowIfNull(template, nameof (template));
    }
}