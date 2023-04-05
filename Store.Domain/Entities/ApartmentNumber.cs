namespace Store.Domain.Entities;

public sealed class ApartmentNumber
{
    private ApartmentNumber(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static implicit operator ApartmentNumber(string value)
    {
        return new ApartmentNumber(value);
    }
}