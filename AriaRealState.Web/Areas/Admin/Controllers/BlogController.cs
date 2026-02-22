using Microsoft.AspNetCore.Mvc;

namespace AriaRealState.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class BlogController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}

