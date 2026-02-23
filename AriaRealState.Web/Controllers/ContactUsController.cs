using Microsoft.AspNetCore.Mvc;

namespace AriaRealState.Web.Controllers;

public class ContactUsController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
