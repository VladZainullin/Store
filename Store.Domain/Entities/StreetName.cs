namespace Store.Domain.Entities;

public sealed class StreetName
{
    private StreetName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static implicit operator StreetName(string value)
    {
        return new StreetName(value);
    }
}