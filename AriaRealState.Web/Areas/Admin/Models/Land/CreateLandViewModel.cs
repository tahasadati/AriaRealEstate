using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Land;

namespace AriaRealState.Web.Areas.Admin.Models.Land;

public class CreateLandViewModel
{
    public string Code { get; set; }
    public string Title { get; set; }

    public decimal ShowPrice { get; set; }
    public decimal MinPrice { get; set; }
    public bool IsShow { get; set; } = true;

    public int LandSize { get; set; }

    public AbilityEnum Ability { get; set; }
    public LandOrientationEnum LandOrientation { get; set; }
    public LandUseType UseType { get; set; }
    public PropertyLocationType LocationType { get; set; }

    public IFormFile? VideoFile { get; set; }
    public IFormFile CoverImageFile { get; set; }
    public List<IFormFile>? GalleriesFile { get; set; }
}
