namespace Domain.Enums.OrderStatuses.Exceptions;

public sealed class CanceledToDeliveredOrderStatusException() : 
    Exception("Нельзя отметить доставленнм отменённый заказ");