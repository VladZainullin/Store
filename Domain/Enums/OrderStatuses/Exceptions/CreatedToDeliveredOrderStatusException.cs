namespace Domain.Enums.OrderStatuses.Exceptions;

public sealed class CreatedToDeliveredOrderStatusException() : 
    Exception("Нельзя отметить доставленным, ещё не взятый в доставку заказ");