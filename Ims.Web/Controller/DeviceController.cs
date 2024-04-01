using Ims.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace;

public class DeviceController : Controller
{
    private readonly IDeviceService _service;

    public DeviceController(IDeviceService service) => _service = service;
    
    // GET: DeviceController
    public ActionResult Index()
    {
        var devices = _service.ListDevices().ToList();
        
        return View();
    }

    // GET: DeviceController/Details/5
    public async Task<ActionResult> Details(Guid id)
    {
        var device = await _service.FindDevice(id);
        
        return View();
    }

    // GET: DeviceController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: DeviceController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: DeviceController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: DeviceController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: DeviceController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: DeviceController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
