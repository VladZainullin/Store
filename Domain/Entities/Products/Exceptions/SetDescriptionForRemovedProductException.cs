namespace Domain.Entities.Products.Exceptions;

public sealed class SetDescriptionForRemovedProductException() : 
    Exception("Нельзя изменить описание удалённого продукта");