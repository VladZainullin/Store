namespace Domain.Entities.Products.Exceptions;

public sealed class SetWhiteSpacesDescriptionForProductException() : 
    Exception("Продукту нельзя задать описание состоящее только из пробелов");