namespace Domain.Entities.Addresses.Exceptions;

public sealed class SetMoreThanMaxLenghtTitleForAddressException()
    : Exception("Наименование адресса доставки не должно превышать 200 символов");