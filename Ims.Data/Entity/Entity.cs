namespace Ims.Data.Entity;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Guid CreatedBy { get; set; } = Guid.Empty;
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}
