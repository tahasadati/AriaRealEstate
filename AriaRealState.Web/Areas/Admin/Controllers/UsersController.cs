using AriaRealState.Data.Entities;
using AriaRealState.Data.Services;
using AriaRealState.Web.Areas.Admin.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AriaRealState.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly UserManager<iUser> _userManager;
    public UsersController(IUserService userService, UserManager<iUser> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }
    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string? q = null)
    {
        ViewBag.Q = q;
        ViewBag.PageSize = pageSize;

        var paginatedUsers = await _userService.GetPaginatedAsync(page, pageSize, q);
        return View(paginatedUsers);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateUserViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUser(CreateUserViewModel viewModel)
    {

        var existUser = await _userManager.FindByNameAsync(viewModel.UserName);
        if (existUser != null)
        {
            ModelState.AddModelError(nameof(viewModel.UserName), "این نام کاربری از قبل وجود دارد.");
            return View("Create", viewModel);
        }

        var user = new iUser
        {
            UserName = viewModel.UserName,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            FullName = viewModel.FullName,
            EmailConfirmed = false,
            RegisterDate = DateTime.Now,
            UserImage = "default-user.png"
        };

        var createResult = await _userManager.CreateAsync(user, viewModel.Password);
        if (!createResult.Succeeded)
        {
            foreach (var err in createResult.Errors)
                ModelState.AddModelError(string.Empty, err.Description);
            return View("Create", viewModel);
        }

        TempData["Success"] = "کاربر با موفقیت ایجاد شد.";
        return RedirectToAction("Index", "Users", new { area = "Admin" });

    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null) return NotFound();

        var roles = (await _userManager.GetRolesAsync(user)).ToList();

        var vm = new EditUserViewModel
        {
            Id = user.Id,
            UserName = user.UserName ?? "",
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            IsActive = !(user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTimeOffset.UtcNow),
            FullName = user.FullName,
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser(EditUserViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Edit", model);

        var user = await _userManager.FindByIdAsync(model.Id);
        if (user == null) return NotFound();

        user.UserName = model.UserName;
        user.Email = model.Email;
        user.PhoneNumber = model.PhoneNumber;
        user.FullName = model.FullName;


        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
            return View("Edit", model);
        }

        TempData["Success"] = "اطلاعات کاربر با موفقیت بروزرسانی شد.";
        return RedirectToAction(nameof(Edit), new { id = model.Id });
    }
}
