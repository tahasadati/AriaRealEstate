using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Land;
using AriaRealState.Data.Services;
using AriaRealState.Web.Models.Land;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AriaRealState.Web.Controllers;

public class LandController : Controller
{
	private readonly ILandService _landService;

	public LandController(ILandService landService)
	{
		_landService = landService;
	}
	public async Task<IActionResult> Buy(string? searchTerm,
        List<AbilityEnum>? selectedAbilities,
        List<LandOrientationEnum>? selectedLandOrientations,
        List<LandUseType>? selectedLandUseTypes,
        List<PropertyLocationType>? selectedPropertyLocationTypes)
	{
        selectedAbilities ??= new();
        selectedLandOrientations ??= new();
        selectedLandUseTypes ??= new();
        selectedPropertyLocationTypes ??= new();

        var lands = await _landService.GetUserList(
           searchTerm,
           selectedAbilities,
           selectedLandOrientations,
           selectedLandUseTypes,
           selectedPropertyLocationTypes
       );
        var viewModels = new List<LandListViewModel>();
        if (lands != null && lands.Count != 0)
        {
            viewModels.AddRange(lands.Select(l => new LandListViewModel
            {
                Code = l.Code,
                Title = l.Title,
                CoverImage = l.CoverImage,
                ShowPrice = l.ShowPrice,
                MinPrice = l.MinPrice,
                IsShow = l.IsShow,
                LandSize = l.LandSize,
                Ability = l.Ability,
                LandOrientation = l.LandOrientation,
                UseType = l.UseType,
                LocationType = l.LocationType,
                VideoLink = l.VideoLink,
                CreateByUserId = l.CreateByUserId,
                IsImmediate = l.IsImmediate
            }));
        }

        return View(viewModels);
	}
}
