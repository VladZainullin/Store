namespace Clients.Contracts;

public interface ICurrentClient<out T>
{
    T ClientId { get; }
}