namespace Store.Domain.Entities;

public sealed class HouseNumber
{
    private HouseNumber(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static implicit operator HouseNumber(string value)
    {
        return new HouseNumber(value);
    }
}