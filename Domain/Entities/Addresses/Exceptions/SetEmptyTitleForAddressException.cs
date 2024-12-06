namespace Domain.Entities.Addresses.Exceptions;

public sealed class SetEmptyTitleForAddressException() :
    Exception("Аддресс доставки не может быть пустым");