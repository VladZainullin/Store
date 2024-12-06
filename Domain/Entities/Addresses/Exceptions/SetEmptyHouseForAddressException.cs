namespace Domain.Entities.Addresses.Exceptions;

public sealed class SetEmptyHouseForAddressException()
    : Exception("Номер дома в адрессе доставки не должен быть пустым");