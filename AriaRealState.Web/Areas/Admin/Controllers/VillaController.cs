using AriaRealState.Data.Entities;
using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Villa;
using AriaRealState.Data.Services;
using AriaRealState.Web.Areas.Admin.Models.Villa;
using AriaRealState.Web.Assistance.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AriaRealState.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class VillaController : Controller
{
	private readonly IVillaService _villaService;
    private readonly IStaticFileService _fileService;
	public VillaController(IVillaService villaService, IStaticFileService fileService)
	{
		_villaService = villaService;
        _fileService = fileService;
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
    public async Task<IActionResult> Create(CreateVillaViewModel vm, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            FillDropdowns();
            return View(vm);
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        if (string.IsNullOrWhiteSpace(userId))
        {
            ModelState.AddModelError("", "شناسه کاربر پیدا نشد.");
            FillDropdowns();
            return View(vm);
        }
        var coverPath = await _fileService.SaveFileAsync(vm.CoverImageFile, "uploads");
        if(string.IsNullOrWhiteSpace(coverPath))
        {
            ModelState.AddModelError("", "خطا در ذخیره تصویر اصلی ویلا");
            FillDropdowns();
            return View(vm);
        } 
        // 2) آپلود ویدیو (اختیاری)
        string? videoPath = null;
        if (vm.VideoFile != null)
            videoPath = await _fileService.SaveFileAsync(vm.VideoFile, "uploads");

        // 3) ساخت Entity
        var model = new AriaRealState.Data.Entities.Villa
        {
            Code = vm.Code,
            Title = vm.Title,
            CoverImage = coverPath,
            ShowPrice = vm.ShowPrice,
            MinPrice = vm.MinPrice,
            IsShow = vm.IsShow,
            InfrastructureSize = vm.InfrastructureSize,
            LandSize = vm.LandSize,
            RoomCount = vm.RoomCount,
            BuildingYear = vm.BuildingYear,
            Description = vm.Description,
            ArchitectureType = vm.ArchitectureType,
            OccupancyStatus = vm.OccupancyStatus,
            LocationType = vm.LocationType,
            VideoLink = videoPath,
            CreateByUserId = userId,
        };

        // 4) آپلود گالری‌ها (اختیاری)
        if (vm.GalleriesFile != null && vm.GalleriesFile.Any())
        {
            foreach (var file in vm.GalleriesFile.Where(f => f != null && f.Length > 0))
            {
                var galleryPath = await _fileService.SaveFileAsync(file, "uploads");
                model.VillaGalleries.Add(new VillaGallery { FilePath = galleryPath });
            }
        }

        var id = await _villaService.CreateAsync(model, ct);
        if (id <= 0)
        {
            ModelState.AddModelError("", "خطا در ذخیره سازی ویلا");
            FillDropdowns();
            return View(vm);
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
