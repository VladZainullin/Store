namespace Domain.Enums.OrderStatuses.Exceptions;

public sealed class CanceledToDeliveringOrderStatusException() : 
    Exception("Нельзя взять в доставку отменённый заказ");