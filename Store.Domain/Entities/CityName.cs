namespace Store.Domain.Entities;

public sealed class CityName
{
    private CityName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static implicit operator CityName(string value)
    {
        return new CityName(value);
    }
}