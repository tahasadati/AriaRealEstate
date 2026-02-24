using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Villa;

namespace AriaRealState.Web.Models.Villa;

public class VillaListViewModel
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
    public bool IsImmediate { get; set; }
}
