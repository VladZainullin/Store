namespace Domain.Entities.Products.Exceptions;

public sealed class SetTitleForRemovedProductException() : 
    Exception("Нельзя изменять наименование удалённого продукта");