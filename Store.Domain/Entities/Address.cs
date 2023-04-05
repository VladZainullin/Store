using Store.Domain.ValueObjects;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace Store.Domain.Entities;

public sealed class Address
{
#pragma warning disable CS8618
    private Address()
#pragma warning restore CS8618
    {
    }

    public Address(
        HouseNumber houseNumber,
        ApartmentNumber apartmentNumber,
        StreetInCity streetInCity) : this()
    {
        HouseNumber = houseNumber;
        ApartmentNumber = apartmentNumber;
        StreetInCity = streetInCity;
    }

    public Id<Guid> Id { get; private set; } = Guid.NewGuid();

    public HouseNumber HouseNumber { get; private set; }
    public ApartmentNumber ApartmentNumber { get; private set; }
    public StreetInCity StreetInCity { get; private set; }
}