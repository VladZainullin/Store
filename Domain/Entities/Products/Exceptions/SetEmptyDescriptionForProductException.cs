namespace Domain.Entities.Products.Exceptions;

public sealed class SetEmptyDescriptionForProductException() : 
    Exception("Нельзя задать пустое описание продукта");