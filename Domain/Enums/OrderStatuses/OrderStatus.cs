using Ardalis.SmartEnum;
using Domain.Enums.OrderStatuses.Exceptions;

namespace Domain.Enums.OrderStatuses;

public abstract class OrderStatus : SmartEnum<OrderStatus>
{
    public static readonly CreatedOrder Created = new();
    public static readonly DeliveringOrder Delivering = new();
    public static readonly DeliveredOrder Delivered = new();
    public static readonly CanceledOrder Canceled = new();
    
    private OrderStatus(string name, int value) : base(name, value)
    {
    }

    public virtual DeliveringOrder ToDelivering()
    {
        return Delivering;
    }

    public virtual DeliveredOrder ToDelivered()
    {
        return Delivered;
    }

    public virtual CanceledOrder ToCanceled()
    {
        return Canceled;
    }

    public sealed class CreatedOrder : OrderStatus
    {
        internal CreatedOrder() : base("Новый", 1)
        {
        }

        public override DeliveredOrder ToDelivered()
        {
            throw new CreatedToDeliveredOrderStatusException();
        }
    }

    public sealed class DeliveringOrder : OrderStatus
    {
        internal DeliveringOrder() : base("Доставляется", 2)
        {
        }
    }

    public sealed class DeliveredOrder : OrderStatus
    {
        internal DeliveredOrder() : base("Доставлен", 3)
        {
            
        }
        
        public override DeliveringOrder ToDelivering()
        {
            throw new DeliveredToDeliveringOrderStatusException();
        }

        public override CanceledOrder ToCanceled()
        {
            throw new DeliveredToCanceledOrderStatusException();
        }
    }

    public sealed class CanceledOrder : OrderStatus
    {
        internal CanceledOrder() : base("Отменён", 4)
        {
        }
        
        public override DeliveringOrder ToDelivering()
        {
            throw new CanceledToDeliveringOrderStatusException();
        }

        public override DeliveredOrder ToDelivered()
        {
            throw new CanceledToDeliveredOrderStatusException();
        }
    }
}