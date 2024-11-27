using Ardalis.SmartEnum;
using Domain.Enums.OrderStatuses.Exceptions;

namespace Domain.Enums.OrderStatuses;

public abstract class OrderStatus : SmartEnum<OrderStatus>
{
    private OrderStatus(string name, int value) : base(name, value)
    {
    }
    
    public abstract DeliveringOrder ToDelivering();
    
    public abstract DeliveredOrder ToDelivered();

    public abstract CanceledOrder ToCanceled();

    public sealed class CreatedOrder : OrderStatus
    {
        private CreatedOrder() : base("Новый", 1)
        {
            
        }
        
        public override DeliveringOrder ToDelivering()
        {
            return new DeliveringOrder();
        }

        public override DeliveredOrder ToDelivered()
        {
            throw new CreatedToDeliveredOrderStatusException();
        }

        public override CanceledOrder ToCanceled()
        {
            return new CanceledOrder();
        }
    }

    public sealed class DeliveringOrder() : OrderStatus("Доставляется", 2)
    {
        public override DeliveringOrder ToDelivering()
        {
            return this;
        }

        public override DeliveredOrder ToDelivered()
        {
            return new DeliveredOrder();
        }

        public override CanceledOrder ToCanceled()
        {
            return new CanceledOrder();
        }
    }

    public sealed class DeliveredOrder() : OrderStatus("Доставлен", 3)
    {
        public override DeliveringOrder ToDelivering()
        {
            throw new DeliveredToDeliveringOrderStatusException();
        }

        public override DeliveredOrder ToDelivered()
        {
            return this;
        }

        public override CanceledOrder ToCanceled()
        {
            throw new DeliveredToCanceledOrderStatusException();
        }
    }

    public sealed class CanceledOrder() : OrderStatus("Отменён", 4)
    {
        public override DeliveringOrder ToDelivering()
        {
            throw new CanceledToDeliveringOrderStatusException();
        }

        public override DeliveredOrder ToDelivered()
        {
            throw new CanceledToDeliveredOrderStatusException();
        }

        public override CanceledOrder ToCanceled()
        {
            return this;
        }
    }
}