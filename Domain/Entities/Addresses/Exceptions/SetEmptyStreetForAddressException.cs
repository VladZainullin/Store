namespace Domain.Entities.Addresses.Exceptions;

public sealed class SetEmptyStreetForAddressException()
    : Exception("Улица в адрессе доставки не должен быть пустым");