using FTBackend.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FTBackend.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DashboardController(IDashboardService dashboardService) : ControllerBase
{
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new UnauthorizedAccessException();

    [HttpGet]
    public async Task<IActionResult> GetDashboard()
    {
        var data = await dashboardService.GetDashboardAsync(UserId);
        return Ok(data);
    }
}
