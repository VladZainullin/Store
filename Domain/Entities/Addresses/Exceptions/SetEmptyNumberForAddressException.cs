namespace Domain.Entities.Addresses.Exceptions;

public sealed class SetEmptyNumberForAddressException() 
    : Exception("Номер помещения в адрессе доставки не должен быть пустым");