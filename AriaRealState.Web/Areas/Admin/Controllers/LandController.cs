using Microsoft.AspNetCore.Mvc;

namespace AriaRealState.Web.Areas.Admin.Controllers;

public class LandController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
