namespace Domain.Entities.Categories.Exceptions;

public sealed class AddProductToRemovedCategoryException() : 
    Exception("Нельзя добавлять продукты в удалённую категорию");