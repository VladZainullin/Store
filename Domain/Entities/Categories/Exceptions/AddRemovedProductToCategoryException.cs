namespace Domain.Entities.Categories.Exceptions;

public sealed class AddRemovedProductToCategoryException()
    : Exception("Нельзя добавлять удалённый продукт в категорию");