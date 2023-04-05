namespace Store.Domain.ValueObjects;

public sealed class Id<T>
{
    private Id(T value)
    {
        Value = value;
    }

    public T Value { get; }

    public static implicit operator Id<T>(T value)
    {
        return new Id<T>(value);
    }
}