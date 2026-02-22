using AriaRealState.Data.Entities;
using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Land;
using AriaRealState.Data.Services;
using AriaRealState.Web.Areas.Admin.Models.Land;
using AriaRealState.Web.Assistance.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AriaRealState.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class LandController : Controller
{
    private readonly ILandService _landService;
    private readonly IStaticFileService _fileService;

    public LandController(ILandService landService, IStaticFileService fileService)
    {
        _landService = landService;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var paginated = await _landService.GetPaginatedAsync(page, pageSize, ct);
        return View(paginated);
    }

    [HttpGet]
    public IActionResult Create()
    {
        FillDropdowns();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateLandViewModel vm, CancellationToken ct)
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

        // Uploads
        var coverPath = await _fileService.SaveFileAsync(vm.CoverImageFile, "uploads");

        string? videoPath = null;
        if (vm.VideoFile != null)
            videoPath = await _fileService.SaveFileAsync(vm.VideoFile, "uploads");

        var land = new Land
        {
            Code = vm.Code,
            Title = vm.Title,
            CoverImage = coverPath,
            ShowPrice = vm.ShowPrice,
            MinPrice = vm.MinPrice,
            IsShow = vm.IsShow,
            LandSize = vm.LandSize,
            Ability = vm.Ability,
            LandOrientation = vm.LandOrientation,
            UseType = vm.UseType,
            LocationType = vm.LocationType,
            VideoLink = videoPath,
            CreateByUserId = userId,

            CallRequests = new List<CallRequest>(),
            CustomerLikedEstates = new List<CustomerLikedEstate>(),
            LandGalleries = new List<LandGallery>()
        };

        if (vm.GalleriesFile != null && vm.GalleriesFile.Any())
        {
            foreach (var file in vm.GalleriesFile.Where(f => f != null && f.Length > 0))
            {
                var galleryPath = await _fileService.SaveFileAsync(file, "uploads");
                land.LandGalleries.Add(new LandGallery { FilePath = galleryPath });
            }
        }

        var id = await _landService.CreateAsync(land, ct);
        if (id <= 0)
        {
            ModelState.AddModelError("", "خطا در ذخیره سازی زمین");
            FillDropdowns();
            return View(vm);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id, CancellationToken ct)
    {
        var land = await _landService.GetByIdAsync(id, ct);
        if (land == null) return NotFound();

        var vm = new EditLandViewModel
        {
            Id = land.Id,
            Code = land.Code,
            Title = land.Title,
            ShowPrice = land.ShowPrice,
            MinPrice = land.MinPrice,
            IsShow = land.IsShow,
            LandSize = land.LandSize,
            Ability = land.Ability,
            LandOrientation = land.LandOrientation,
            UseType = land.UseType,
            LocationType = land.LocationType,
            CurrentCoverImage = land.CoverImage,
            CurrentVideoLink = land.VideoLink
        };

        FillDropdowns();
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, EditLandViewModel vm, CancellationToken ct)
    {
        if (id != vm.Id) return BadRequest();

        var land = await _landService.GetByIdAsync(id, ct);
        if (land == null) return NotFound();

        if (!ModelState.IsValid)
        {
            FillDropdowns();
            return View(vm);
        }

        // اگر فایل جدید ارسال شد، جایگزین کن؛ وگرنه قبلی بماند
        if (vm.CoverImageFile != null && vm.CoverImageFile.Length > 0)
            land.CoverImage = await _fileService.SaveFileAsync(vm.CoverImageFile, "uploads");

        if (vm.VideoFile != null && vm.VideoFile.Length > 0)
            land.VideoLink = await _fileService.SaveFileAsync(vm.VideoFile, "uploads");

        // فیلدها
        land.Code = vm.Code;
        land.Title = vm.Title;
        land.ShowPrice = vm.ShowPrice;
        land.MinPrice = vm.MinPrice;
        land.IsShow = vm.IsShow;
        land.LandSize = vm.LandSize;
        land.Ability = vm.Ability;
        land.LandOrientation = vm.LandOrientation;
        land.UseType = vm.UseType;
        land.LocationType = vm.LocationType;

        // گالری جدید (اضافه می‌کنیم)
        if (vm.GalleriesFile != null && vm.GalleriesFile.Any())
        {
            land.LandGalleries ??= new List<LandGallery>();
            foreach (var file in vm.GalleriesFile.Where(f => f != null && f.Length > 0))
            {
                var galleryPath = await _fileService.SaveFileAsync(file, "uploads");
                land.LandGalleries.Add(new LandGallery { FilePath = galleryPath });
            }
        }

        var ok = await _landService.UpdateAsync(land, ct);
        if (!ok)
        {
            ModelState.AddModelError("", "خطا در بروزرسانی زمین");
            FillDropdowns();
            return View(vm);
        }

        return RedirectToAction(nameof(Index));
    }

   

    private void FillDropdowns()
    {
        ViewBag.Abilities = Enum.GetValues(typeof(AbilityEnum)).Cast<AbilityEnum>();
        ViewBag.Orientations = Enum.GetValues(typeof(LandOrientationEnum)).Cast<LandOrientationEnum>();
        ViewBag.UseTypes = Enum.GetValues(typeof(LandUseType)).Cast<LandUseType>();
        ViewBag.LocationTypes = Enum.GetValues(typeof(PropertyLocationType)).Cast<PropertyLocationType>();
    }

}
