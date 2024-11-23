namespace Domain.Entities.Products.Exceptions;

public sealed class SetLessThanZeroQuantityForProductException()
    : Exception("Нельзя задать кол-во продукта меньше нуля");