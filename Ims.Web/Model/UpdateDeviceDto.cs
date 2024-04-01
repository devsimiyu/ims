using System.ComponentModel.DataAnnotations;
using Ims.Data.Enums;

namespace Ims.Web.Model;

public record UpdateDeviceDto
{
    [Required]
    public Guid Id { get; set; } = Guid.Empty;
    
    [Required]
    public string CpuSerial { get; set; } = string.Empty;

    [Required]
    public string CpuTag { get; set; } = string.Empty;

    [Required]
    public string MonitorSerial { get; set; } = string.Empty;

    [Required]
    public string MonitorTag { get; set; } = string.Empty;

    [Required]
    public string Model { get; set; } = string.Empty;

    [Required]
    public string OperatingSystem { get; set; } = string.Empty;

    [EnumDataType(typeof(DeviceStatus))]
    public DeviceStatus Status { get; set; }

    [EnumDataType(typeof(DeviceType))]
    public DeviceType Type { get; set; }

    [Required]
    public DateTime PurchaseDate { get; set; }
}
