using FTBackend.Core.Entities;
using FTBackend.Core.DTOs;

public async Task<ReportDto<TransactionItemDto>> GetIncomeReportAsync(string userId)
{
    var transactions = await _transactionRepository.GetByUserIdAsync(userId);

    var income = transactions.Where(t => t.Type == TransactionType.Income);

    var categories = income
        .GroupBy(t => t.Category)
        .Select(group => new ReportCategoryDto<TransactionItemDto>(
            group.Key,
            group.Select(t => new TransactionItemDto(
                t.Id,
                t.Category,
                t.Description,
                t.Amount
            ))
        ));

    var total = income.Sum(t => t.Amount);

    return new ReportDto<TransactionItemDto>(categories, total);
}
