using Microsoft.AspNetCore.Mvc;

namespace AriaRealState.Web.Controllers;

public class AboutUsController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
