namespace Domain.Entities.Products.Exceptions;

public sealed class SetWhiteSpacesTitleForProductException() : 
    Exception("Продукту нельзя задать наименование состоящее только из пробелов");