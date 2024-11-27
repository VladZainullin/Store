namespace Domain.Enums.OrderStatuses.Exceptions;

public sealed class DeliveredToDeliveringOrderStatusException() : 
    Exception("Нельзя взять в достувку, уже доставленный заказ");