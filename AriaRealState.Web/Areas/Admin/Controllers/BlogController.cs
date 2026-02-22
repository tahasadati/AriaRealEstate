using AriaRealState.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace AriaRealState.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class BlogController : Controller
{
    private readonly IBlogService _blogService;
	public BlogController(IBlogService blogService)
	{
		_blogService = blogService;
	}
	public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var paginatedBlogs = await _blogService.GetPaginatedAsync(page, pageSize);
        return View(paginatedBlogs);
    }
}

