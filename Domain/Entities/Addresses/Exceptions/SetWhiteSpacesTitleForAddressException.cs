namespace Domain.Entities.Addresses.Exceptions;

public sealed class SetWhiteSpacesTitleForAddressException() :
    Exception("Аддресс доставки не может состоять только из пробелов");