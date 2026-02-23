using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Villa;
using AriaRealState.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Entities;

public class Villa : BaseEntity
{
    public required string Code { get; set; }
    public required string Title { get; set; }
    public required string CoverImage { get; set; }
    public required decimal ShowPrice { get; set; }
    public required decimal MinPrice { get; set; }
    public bool IsShow { get; set; } = true;
    public required int InfrastructureSize { get; set; }
    public required int LandSize { get; set; }
    public required int RoomCount { get; set; }
    public required int BuildingYear { get; set; }
    public required string Description { get; set; }
    public VillaArchitectureType ArchitectureType { get; set; }
    public VillaOccupancyStatus OccupancyStatus { get; set; }
    public PropertyLocationType LocationType { get; set; }
    public string? VideoLink { get; set; }
    public string CreateByUserId { get; set; }


    public ICollection<CallRequest> CallRequests { get; set; } = new List<CallRequest>();
    public ICollection<CustomerLikedEstate> CustomerLikedEstates { get; set; } = new List<CustomerLikedEstate>();
    public ICollection<VillaAdvanceFacility> VillaAdvanceFacilities { get; set; } = new List<VillaAdvanceFacility>();
    public ICollection<VillaGallery> VillaGalleries { get; set; } = new List<VillaGallery>();

    public iUser CreatedByUser { get; set; }


}
