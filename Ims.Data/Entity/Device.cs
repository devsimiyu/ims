using Ims.Data.Enums;

namespace Ims.Data.Entity;

public class Device : Entity
{
    public string CpuSerial { get; set; } = string.Empty;
    public string CpuTag { get; set; } = string.Empty;
    public string MonitorSerial { get; set; } = string.Empty;
    public string MonitorTag { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string OperatingSystem { get; set; } = string.Empty;
    public DeviceStatus Status { get; set; }
    public DeviceType Type { get; set; }
    public DateTime PurchaseDate { get; set; }
}
