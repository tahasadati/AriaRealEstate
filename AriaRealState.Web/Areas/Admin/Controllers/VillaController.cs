using Microsoft.AspNetCore.Mvc;

namespace AriaRealState.Web.Areas.Admin.Controllers;

public class VillaController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
