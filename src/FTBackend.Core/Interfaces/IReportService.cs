using FTBackend.Core.DTOs;

namespace FTBackend.Core.Interfaces;

public interface IReportService
{
    Task<ReportDto<TransactionItemDto>> GetIncomeReportAsync(string userId);
    Task<ReportDto<TransactionItemDto>> GetExpensesReportAsync(string userId);
    Task<ReportDto<AssetItemDto>> GetAssetsReportAsync(string userId);
    Task<ReportDto<LiabilityItemDto>> GetLiabilitiesReportAsync(string userId);
}
