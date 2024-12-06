namespace Domain.Entities.Addresses.Exceptions;

public sealed class SetEmptyRootForAddressException() 
    : Exception("Этаж в адрессе доставки не должен быть пустым");