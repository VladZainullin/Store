namespace Domain.Entities.Addresses.Exceptions;

public sealed class SetEmptyCityForAddressException()
    : Exception("Город в адрессе доставки не должен быть пустым");