namespace Domain.Entities.Products.Exceptions;

public sealed class FavoriteRemovedProductException() : 
    Exception("Нельзя сделать избранным, удалённый товар");