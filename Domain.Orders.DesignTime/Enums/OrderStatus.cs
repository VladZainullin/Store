using Ardalis.SmartEnum;

namespace Domain.Enums;

public abstract class OrderStatus : SmartEnum<OrderStatus>
{
    public static NewStatus New => new();

    private OrderStatus(string name, int value) : base(name, value)
    {
    }
    
    public sealed class NewStatus : OrderStatus
    {
        internal NewStatus() : base("Новый", 1)
        {
        }
    }
}