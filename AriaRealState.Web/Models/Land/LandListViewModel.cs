using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Land;

namespace AriaRealState.Web.Models.Land;

public class LandListViewModel
{
    public required string Code { get; set; }
    public required string Title { get; set; }
    public required string CoverImage { get; set; }
    public required decimal ShowPrice { get; set; }
    public required decimal MinPrice { get; set; }
    public bool IsShow { get; set; } = true;
    public required int LandSize { get; set; }

    public AbilityEnum Ability { get; set; }
    public LandOrientationEnum LandOrientation { get; set; }
    public LandUseType UseType { get; set; }
    public PropertyLocationType LocationType { get; set; }

    public string? VideoLink { get; set; }
    public string CreateByUserId { get; set; }
    public bool IsImmediate { get; set; }
}
