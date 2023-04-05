using Store.Domain.ValueObjects;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace Store.Domain.Entities;

public sealed class Shop
{
#pragma warning disable CS8618
    private Shop()
#pragma warning restore CS8618
    {
    }

    public Shop(Address address) : this()
    {
        Address = address;
    }

    public Id<Guid> Id { get; private set; } = Guid.NewGuid();

    public Address Address { get; private set; }
}