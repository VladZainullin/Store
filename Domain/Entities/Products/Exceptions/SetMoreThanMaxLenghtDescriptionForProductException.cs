namespace Domain.Entities.Products.Exceptions;

public class SetMoreThanMaxLenghtDescriptionForProductException() : 
    Exception("Описание продукта не должно превышать 6000 символов");