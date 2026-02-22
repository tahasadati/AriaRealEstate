using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Land;

namespace AriaRealState.Web.Areas.Admin.Models.Land;

public class EditLandViewModel
{
    public long Id { get; set; }

    public required string Code { get; set; }
    public required string Title { get; set; }

    public required decimal ShowPrice { get; set; }
    public required decimal MinPrice { get; set; }
    public bool IsShow { get; set; } = true;

    public required int LandSize { get; set; }

    public AbilityEnum Ability { get; set; }
    public LandOrientationEnum LandOrientation { get; set; }
    public LandUseType UseType { get; set; }
    public PropertyLocationType LocationType { get; set; }

    // فایل‌های جدید (اختیاری)
    public IFormFile? VideoFile { get; set; }
    public IFormFile? CoverImageFile { get; set; }
    public List<IFormFile>? GalleriesFile { get; set; }

    // نمایش فایل‌های فعلی
    public string? CurrentCoverImage { get; set; }
    public string? CurrentVideoLink { get; set; }
}
