namespace Domain.Entities.Products.Exceptions;

public sealed class SetEmptyTitleForProductException() : 
    Exception("Нельзя задать пустое наименование продукта");