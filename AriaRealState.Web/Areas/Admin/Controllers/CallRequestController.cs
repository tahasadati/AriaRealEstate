using AriaRealState.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AriaRealState.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class CallRequestController : Controller
{
    private readonly ICallRequestService _callRequestService;

    public CallRequestController(ICallRequestService callRequestService)
    {
        _callRequestService = callRequestService;
    }

    // لیست صفحه‌بندی شده
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10, CancellationToken ct = default)
    {
        var paginated = await _callRequestService.GetPaginatedAsync(page, pageSize, ct);
        return View(paginated);
    }

    // مشاهده تکی
    [HttpGet]
    public async Task<IActionResult> Details(long id, CancellationToken ct = default)
    {
        var item = await _callRequestService.GetByIdAsync(id, ct);
        if (item == null) return NotFound();

        return View(item);
    }
}