namespace Domain.Enums.OrderStatuses.Exceptions;

public sealed class DeliveredToCanceledOrderStatusException() : 
    Exception("Нельзя отменить уже доставленный товар");