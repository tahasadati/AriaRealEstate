using AriaRealState.Data.Entities;
using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Villa;
using AriaRealState.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AriaRealState.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class VillaController : Controller
{
	private readonly IVillaService _villaService;
	public VillaController(IVillaService villaService)
	{
		_villaService = villaService;
	}
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var paginatedVillas = await _villaService.GetPaginatedAsync(page, pageSize);
        return View(paginatedVillas);
    }

    [HttpGet]
    public IActionResult Create()
    {
        FillDropdowns();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Villa model, CancellationToken ct)
    {
        
        model.CallRequests = new List<CallRequest>();
        model.CustomerLikedEstates = new List<CustomerLikedEstate>();
        model.VillaAdvanceFacilities = new List<VillaAdvanceFacility>();
        model.VillaGalleries = new List<VillaGallery>();

        
        model.CreateByUserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        if (string.IsNullOrWhiteSpace(model.CreateByUserId))
            ModelState.AddModelError("", "شناسه کاربر پیدا نشد.");

        if (!ModelState.IsValid)
        {
            FillDropdowns();
            return View(model);
        }

        var id = await _villaService.CreateAsync(model, ct);
        if (id <= 0)
        {
            ModelState.AddModelError("", "خطا در ذخیره سازی ویلا");
            FillDropdowns();
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id, CancellationToken ct)
    {
        var villa = await _villaService.GetByIdAsync(id, ct);
        if (villa == null) return NotFound();

        FillDropdowns();
        return View(villa);
    }



    private void FillDropdowns()
    {
        ViewBag.ArchitectureTypes = Enum.GetValues(typeof(VillaArchitectureType)).Cast<VillaArchitectureType>();
        ViewBag.OccupancyStatuses = Enum.GetValues(typeof(VillaOccupancyStatus)).Cast<VillaOccupancyStatus>();
        ViewBag.LocationTypes = Enum.GetValues(typeof(PropertyLocationType)).Cast<PropertyLocationType>();
    }
}
