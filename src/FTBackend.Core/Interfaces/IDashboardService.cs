using FTBackend.Core.DTOs;

namespace FTBackend.Core.Interfaces;

public interface IDashboardService
{
    Task<DashboardDto> GetDashboardAsync(string userId);
}
