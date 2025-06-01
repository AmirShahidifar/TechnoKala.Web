using Microsoft.AspNetCore.Mvc;
using TechnoKala.CoreLayer.Servises.Permissions;
using TechnoKala.CoreLayer.Dtos;

namespace TechnoKala.Areas.Panel.Controllers;

[Area("Panel")]
public class PermissionController : Controller
{
    private readonly IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    public async Task<IActionResult> Index()
    {
        var permissions = await _permissionService.GetAllAsync();
        return View(permissions);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePermissionDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await _permissionService.CreatePermissionAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var permission = await _permissionService.GetByIdAsync(id);
        if (permission == null)
            return NotFound();

        var model = new UpdatePermissionDto
        {
            Id = permission.Id,
            Name = permission.Name
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdatePermissionDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var result = await _permissionService.UpdatePermissionAsync(dto);
        if (!result)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _permissionService.DeletePermissionAsync(id);
        if (!result)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }
}
