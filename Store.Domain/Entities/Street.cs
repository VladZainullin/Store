using Store.Domain.ValueObjects;

namespace Store.Domain.Entities;

public sealed class Street
{
#pragma warning disable CS8618
    private Street()
#pragma warning restore CS8618
    {
    }

    public Street(StreetName name) : this()
    {
        Name = name;
    }

    public Id<Guid> Id { get; set; } = Guid.NewGuid();

    public StreetName Name { get; }
}