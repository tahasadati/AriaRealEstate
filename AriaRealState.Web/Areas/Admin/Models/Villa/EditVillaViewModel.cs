using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Villa;
using System.ComponentModel.DataAnnotations;

namespace AriaRealState.Web.Areas.Admin.Models.Villa
{
    public class ExistingGalleryItemVm
{
    public long Id { get; set; }
    public string FilePath { get; set; }
}

public class EditVillaViewModel
{
    public long Id { get; set; }

    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public string Code { get; set; }

    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public string Title { get; set; }

    public decimal ShowPrice { get; set; }
    public decimal MinPrice { get; set; }
    public bool IsShow { get; set; } = true;

    public int InfrastructureSize { get; set; }
    public int LandSize { get; set; }
    public int RoomCount { get; set; }
    public int BuildingYear { get; set; }

    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public string Description { get; set; }

    public VillaArchitectureType ArchitectureType { get; set; }
    public VillaOccupancyStatus OccupancyStatus { get; set; }
    public PropertyLocationType LocationType { get; set; }

    // آپلودهای جدید (اختیاری)
    public IFormFile? VideoFile { get; set; }
    public IFormFile? CoverImageFile { get; set; }
    public List<IFormFile>? GalleriesFile { get; set; }

    // فایل‌های موجود برای نمایش
    public string? ExistingVideoPath { get; set; }
    public string? ExistingCoverPath { get; set; }
    public List<ExistingGalleryItemVm> ExistingGalleries { get; set; } = new();

    // حذف‌ها
    public bool RemoveVideo { get; set; }
    public bool RemoveCover { get; set; }
    public List<long> RemoveGalleryIds { get; set; } = new();

    // امکانات
    public List<AdvanceFacilityEnum> SelectedAdvanceFacilities { get; set; } = new();
    public List<AdvanceFacilityEnum> ExistingAdvanceFacilities { get; set; } = new();
}
}