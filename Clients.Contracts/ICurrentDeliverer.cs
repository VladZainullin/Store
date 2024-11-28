namespace Clients.Contracts;

public interface ICurrentDeliverer<out T>
{
    T DelivererId { get; }
}