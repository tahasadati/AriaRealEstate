using AriaRealState.Data.Entities;
using AriaRealState.Data.Services;
using AriaRealState.Web.Areas.Admin.Models.Neighborhood;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AriaRealState.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class NeighborhoodController : Controller
{
    private readonly INeighborhoodService _neighborhoodService;

    public NeighborhoodController(INeighborhoodService neighborhoodService)
    {
        _neighborhoodService = neighborhoodService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var paginated = await _neighborhoodService.GetPaginatedAsync(page, pageSize, ct);
        return View(paginated);
    }

    // ================= CREATE =================

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateNeighborhoodViewModel vm, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var entity = new Neighborhood
        {
            NeighborhoodName = vm.NeighborhoodName
        };

        var id = await _neighborhoodService.CreateAsync(entity, ct);
        if (id <= 0)
        {
            ModelState.AddModelError("", "خطا در ذخیره سازی محله");
            return View(vm);
        }

        return RedirectToAction(nameof(Index));
    }

    // ================= EDIT =================

    [HttpGet]
    public async Task<IActionResult> Edit(long id, CancellationToken ct)
    {
        var entity = await _neighborhoodService.GetByIdAsync(id, ct);
        if (entity == null)
            return NotFound();

        var vm = new EditNeighborhoodViewModel
        {
            Id = entity.Id,
            NeighborhoodName = entity.NeighborhoodName
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, EditNeighborhoodViewModel vm, CancellationToken ct)
    {
        if (id != vm.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(vm);

        var entity = await _neighborhoodService.GetByIdAsync(id, ct);
        if (entity == null)
            return NotFound();

        entity.NeighborhoodName = vm.NeighborhoodName;

        var ok = await _neighborhoodService.UpdateAsync(entity, ct);
        if (!ok)
        {
            ModelState.AddModelError("", "خطا در بروزرسانی محله");
            return View(vm);
        }

        return RedirectToAction(nameof(Index));
    }
}