using Domain.Enums.DelivererStatuses;

namespace Domain.Entities.Deliverers;

public sealed class Deliverer
{
    private Guid _id = Guid.CreateVersion7();
    private DelivererStatus _status = DelivererStatus.NotWorking;
    
    private Deliverer()
    {
    }
}