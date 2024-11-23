namespace Domain.Entities.Categories.Exceptions;

public sealed class RemoveProductFromRemovedCategoryException() : 
    Exception("Нельзя удалять продукты из удалённой категории");