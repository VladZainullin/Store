namespace Domain.Entities.Categories.Exceptions;

public sealed class RemoveRemovedProductFromCategoryException() : 
    Exception("Нельзя удалять удалённый продукт категории");