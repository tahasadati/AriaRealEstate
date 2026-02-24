using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Villa;
using AriaRealState.Data.Services;
using AriaRealState.Web.Models.Villa;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AriaRealState.Web.Controllers;

public class VillaController : Controller
{
	private readonly IVillaService _villaService;
	public VillaController(IVillaService villaService)
	{
		_villaService = villaService; 
	}
	public async Task<IActionResult> Buy(string searchTerm, List<VillaArchitectureType> selectedArchitectureTypes, List<PropertyLocationType> selectedLocationTypes, List<VillaOccupancyStatus> selectedOccupancyStatuses, int size = 45)
	{
		var villas = await _villaService.GetUserList(searchTerm,
                selectedArchitectureTypes,
                selectedLocationTypes,
                selectedOccupancyStatuses);
		var viewModels = new List<VillaListViewModel>();
        if (villas != null && villas.Count != 0)
		{
			viewModels.AddRange(villas.Select(v => new VillaListViewModel
			{
				Code = v.Code,
				Title = v.Title,
				CoverImage = v.CoverImage,
				ShowPrice = v.ShowPrice,
				MinPrice = v.MinPrice,
				IsShow = v.IsShow,
				InfrastructureSize = v.InfrastructureSize,
				LandSize = v.LandSize,
				RoomCount = v.RoomCount,
				BuildingYear = v.BuildingYear,
				Description = v.Description,
				ArchitectureType = v.ArchitectureType,
				OccupancyStatus = v.OccupancyStatus,
				LocationType = v.LocationType,
				VideoLink = v.VideoLink,
				CreateByUserId = v.CreateByUserId,
				IsImmediate = v.IsImmediate,
			}));
        }
        return View(viewModels);
	}
}
