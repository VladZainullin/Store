using System.Security.Claims;

namespace Web.Services;

public sealed class CurrentUser(IHttpContextAccessor httpContextAccessor)
{
    public bool TryGetId(out Guid? id)
    {
        var value = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (Guid.TryParse(value, out var temp))
        {
            id = temp;
            return true;
        }

        id = null;
        return false;
    }
}