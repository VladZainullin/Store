namespace Domain.Entities.Addresses.Exceptions;

public sealed class SetEmptyTitleForAddressException() :
    Exception("Наименование адресса доставки не может быть пустым");