using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Land;
using AriaRealState.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Entities;

public class Land : BaseEntity
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

    public ICollection<CallRequest> CallRequests { get; set; }
    public ICollection<CustomerLikedEstate> CustomerLikedEstates { get; set; }
    public ICollection<LandGallery> LandGalleries { get; set; }

    public iUser CreatedByUser { get; set; }


}
