namespace Domain.Entities.Products.Exceptions;

public sealed class SetCostForRemovedProductException() : 
    Exception("Нельзя изменять стоимость удалённого продукта");