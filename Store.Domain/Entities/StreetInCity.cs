namespace Store.Domain.Entities;

public class StreetInCity
{
#pragma warning disable CS8618
    private StreetInCity()
#pragma warning restore CS8618
    {
    }

    public StreetInCity(
        Street street,
        City city) : this()
    {
        Street = street;
        City = city;
    }

    public Guid StreetId { get; set; }
    public virtual Street Street { get; }

    public Guid CityId { get; set; }
    public virtual City City { get; }
}