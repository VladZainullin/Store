namespace Domain.Entities.Products.Exceptions;

public sealed class SetLessOrEqualZeroCostForProductException()
    : Exception("Стоимость продукта не может быть меньше либо равна нулю");