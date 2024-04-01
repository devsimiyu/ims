using Ims.Web.Model;
using Ims.Data.Context;
using Ims.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ims.Web;

public interface IDeviceRepository
{
    IQueryable<Device> ListDevices();
    Task<Device?> FindDevice(Guid id);
    Task<Device> AddDevice(AddDeviceDto dto);
    Task UpdateDevice(UpdateDeviceDto dto, Device device);
    Task<int> DeleteDevice(Guid id);
}

public class DeviceRepository : IDeviceRepository
{
    private readonly PersistenceContext _context;

    public DeviceRepository(PersistenceContext context) => _context = context;

    public IQueryable<Device> ListDevices() => _context.Devices.AsQueryable().AsNoTracking();

    public async Task<Device?> FindDevice(Guid id) => await _context.Devices.FindAsync(id);
    
    public async Task<Device> AddDevice(AddDeviceDto dto)
    {
        var device = new Device
        {
            CpuSerial = dto.CpuSerial,
            CpuTag = dto.CpuTag,
            MonitorSerial = dto.MonitorSerial,
            MonitorTag = dto.MonitorTag,
            Model = dto.Model,
            OperatingSystem = dto.OperatingSystem,
            Type = dto.Type,
            PurchaseDate = dto.PurchaseDate,
            Status = dto.Status,
        };

        await _context.Devices.AddAsync(device);
        await _context.SaveChangesAsync();

        return device;
    }

    public async Task UpdateDevice(UpdateDeviceDto dto, Device device)
    {
        device.CpuSerial = dto.CpuSerial;
        device.CpuTag = dto.CpuTag;
        device.MonitorSerial = dto.MonitorSerial;
        device.MonitorTag = dto.MonitorTag;
        device.Model = dto.Model;
        device.OperatingSystem = dto.OperatingSystem;
        device.Type = dto.Type;
        device.PurchaseDate = dto.PurchaseDate;
        device.Status = dto.Status;

        await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteDevice(Guid id)
    {
        var entry = _context.Devices.Local.FindEntry(id);

        if (entry == null)
        {
            return await _context.Devices.Where(device => device.Id.Equals(id)).ExecuteDeleteAsync();
        }

        var device = entry.Entity;

        _context.Devices.Remove(device);
        
        return await _context.SaveChangesAsync();
    }
}
