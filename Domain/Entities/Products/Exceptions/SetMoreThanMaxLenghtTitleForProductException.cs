namespace Domain.Entities.Products.Exceptions;

public sealed class SetMoreThanMaxLenghtTitleForProductException() : 
    Exception("Наименование продукта не должно превышать 256 символов");