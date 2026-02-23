using AriaRealState.Data.Services;
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
	public async Task<IActionResult> Buy(int size = 45)
	{
		var villas = await _villaService.GetUserList(size);
		//var
        return View();
	}
}
