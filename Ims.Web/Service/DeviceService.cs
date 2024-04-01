using Ims.Data.Entity;
using Ims.Web.Model;
using Microsoft.EntityFrameworkCore;

namespace Ims.Web.Service;

public interface IDeviceService
{
    IQueryable<Device> ListDevices();
    Task<Device?> FindDevice(Guid id);
    Task<Device> AddDevice(AddDeviceDto addDeviceDto);
    Task<Device?> UpdateDevice(UpdateDeviceDto dto);
    Task<bool> DeleteDevice(Guid id);
}

public class DeviceService : IDeviceService
{
    private readonly IDeviceRepository _repository;

    public DeviceService(IDeviceRepository repository) => _repository = repository;

    public IQueryable<Device> ListDevices() => _repository.ListDevices();

    public Task<Device?> FindDevice(Guid id) => _repository.FindDevice(id);

    public Task<Device> AddDevice(AddDeviceDto addDeviceDto) => _repository.AddDevice(addDeviceDto);

    public async Task<Device?> UpdateDevice(UpdateDeviceDto dto)
    {
        var device = await _repository
            .ListDevices()
            .SingleOrDefaultAsync(device => device.Id.Equals(dto.Id));

        if (device != null)
        {
            await _repository.UpdateDevice(dto, device);
        }

        return device;
    }

    public async Task<bool> DeleteDevice(Guid id)
    {
        var result = await _repository.DeleteDevice(id);

        return result == 1;
    }
}
