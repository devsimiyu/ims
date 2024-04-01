using Ims.Data.Enums;

namespace Ims.Data.Entity;

public class DeviceAssignment : Entity
{
    public DateTime DateAssigned { get; set; } = DateTime.UtcNow;
    public DeviceStatus Status { get; set; }
    public string Note { get; set; } = string.Empty;
    public Guid DeviceId { get; set; }
    public Guid UserId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid TicketId { get; set; }

    public Device Device { get; set; } = null!;
    public User User { get; set; } = null!;
    public Department Department { get; set; } = null!;
    public Ticket Ticket { get; set; } = null!;
}
