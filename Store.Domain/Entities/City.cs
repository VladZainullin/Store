using Store.Domain.ValueObjects;

namespace Store.Domain.Entities;

public sealed class City
{
#pragma warning disable CS8618
    private City()
#pragma warning restore CS8618
    {
    }

    public City(CityName name) : this()
    {
        Name = name;
    }

    public Id<Guid> Id { get; set; } = Guid.NewGuid();

    public CityName Name { get; }
}