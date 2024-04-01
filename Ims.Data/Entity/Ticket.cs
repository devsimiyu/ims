using Ims.Data.Enums;

namespace Ims.Data.Entity;

public class Ticket : Entity
{
    public TicketStatus Status { get; set; } = TicketStatus.PENDING;
    public TicketType Type { get; set; }
    public string Note { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid DepartmentId { get; set; }

    public User User { get; set; } = null!;
    public Department Department { get; set; } = null!;
}
