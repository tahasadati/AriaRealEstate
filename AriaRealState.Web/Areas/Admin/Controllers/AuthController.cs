using AriaRealState.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AriaRealState.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class AuthController : Controller
{
	private readonly UserManager<iUser> _userManager;
	private readonly SignInManager<iUser> _signInManager;

	public AuthController(UserManager<iUser> userManager, SignInManager<iUser> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}

	public IActionResult Login()
	{
		return View();
	}

	public async Task<IActionResult> Login(string username, string password)
	{
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            TempData["Error"] = "نام کاربری و رمز عبور الزامی است.";
            return View();
        }
        var user = await _userManager.FindByNameAsync(username);
		if (user == null)
		{
            TempData["Error"] = "کاربری با این مشخصات یافت نشد.";
            return View();
        }
		var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
		if (result.Succeeded)
		{
			return RedirectToAction("Index", "Home");
		}
		ModelState.AddModelError("", "Invalid email or password.");
		return View();
    }
}
