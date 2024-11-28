using Ardalis.SmartEnum;

namespace Domain.Enums.DelivererStatuses;

public abstract class DelivererStatus : SmartEnum<DelivererStatus>
{
    public static readonly WorkingStatus Working = new();
    public static readonly NotWorkingStatus NotWorking = new();
    
    protected internal DelivererStatus(string name, int value) : base(name, value)
    {
    }

    public WorkingStatus ToWorking()
    {
        return Working;
    }

    public NotWorkingStatus ToNotWorking()
    {
        return NotWorking;
    }
    
    public sealed class WorkingStatus : DelivererStatus
    {
        internal WorkingStatus() : base("Работаю", 1)
        {
        }
    }
    
    public sealed class NotWorkingStatus : DelivererStatus
    {
        internal NotWorkingStatus() : base("Не работаю", 2)
        {
        }
    }
}