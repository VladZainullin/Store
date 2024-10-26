namespace Clients.Contracts;

public interface ICurrentClient<out T> where T : unmanaged
{
    T ClientId { get; }
}