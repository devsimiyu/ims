using Ims.Data.Enums;

namespace Ims.Data.Entity;

public class User : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public Guid DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual ICollection<DeviceAssignment> DeviceAssignments { get; set; } = new List<DeviceAssignment>();
}
