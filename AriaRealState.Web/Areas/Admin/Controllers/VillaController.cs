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
        if (string.IsNullOrWhiteSpace(coverPath))
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

        if (vm.SelectedAdvanceFacilities != null && vm.SelectedAdvanceFacilities.Any())
        {
            foreach (var facility in vm.SelectedAdvanceFacilities.Distinct())
            {
                model.VillaAdvanceFacilities.Add(new VillaAdvanceFacility
                {
                    AdvanceFacility = facility
                });
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

        var vm = new EditVillaViewModel
        {
            Id = villa.Id,
            Code = villa.Code,
            Title = villa.Title,
            ShowPrice = villa.ShowPrice,
            MinPrice = villa.MinPrice,
            IsShow = villa.IsShow,
            InfrastructureSize = villa.InfrastructureSize,
            LandSize = villa.LandSize,
            RoomCount = villa.RoomCount,
            BuildingYear = villa.BuildingYear,
            Description = villa.Description,
            ArchitectureType = villa.ArchitectureType,
            OccupancyStatus = villa.OccupancyStatus,
            LocationType = villa.LocationType,

            ExistingVideoPath = villa.VideoLink,
            ExistingCoverPath = villa.CoverImage,

            ExistingGalleries = villa.VillaGalleries
                .OrderByDescending(x => x.Id)
                .Select(x => new ExistingGalleryItemVm
                {
                    Id = x.Id,
                    FilePath = x.FilePath
                })
                .ToList(),

            ExistingAdvanceFacilities = villa.VillaAdvanceFacilities
                .Select(x => x.AdvanceFacility)
                .ToList(),

            SelectedAdvanceFacilities = villa.VillaAdvanceFacilities
                .Select(x => x.AdvanceFacility)
                .ToList()
        };

        FillDropdowns();
        return View(vm);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(EditVillaViewModel vm, CancellationToken ct)
    {
        var villa = await _villaService.GetByIdAsync(vm.Id, ct);
        if (villa == null) return NotFound();
        if (vm.VideoFile != null)
        {
            var videoPath = await _fileService.SaveFileAsync(vm.VideoFile, "uploads");
            villa.VideoLink = videoPath;
        }
        //Todo : mist be complete
        return RedirectToAction(nameof(Index));

    }



    public async Task<IActionResult> Delete(long id, CancellationToken ct)
    {
        var villa = await _villaService.GetByIdAsync(id, ct);
        if (villa == null) return NotFound();
        var isSuccess = await _villaService.RemoveAsync(villa);
        if(isSuccess)
        {
            TempData["Success"] = "ویلا با موفقیت حذف شد.";
            return RedirectToAction(nameof(Index));
        }
        else
        {
            TempData["Error"] = "خطا در حذف ویلا. لطفاً دوباره تلاش کنید.";
            return RedirectToAction(nameof(Index));
        }

    }


    private void FillDropdowns()
    {
        ViewBag.ArchitectureTypes = Enum.GetValues(typeof(VillaArchitectureType)).Cast<VillaArchitectureType>();
        ViewBag.OccupancyStatuses = Enum.GetValues(typeof(VillaOccupancyStatus)).Cast<VillaOccupancyStatus>();
        ViewBag.LocationTypes = Enum.GetValues(typeof(PropertyLocationType)).Cast<PropertyLocationType>();
        ViewBag.AdvanceFacilities = Enum.GetValues(typeof(AdvanceFacilityEnum)).Cast<AdvanceFacilityEnum>();
    }
}
