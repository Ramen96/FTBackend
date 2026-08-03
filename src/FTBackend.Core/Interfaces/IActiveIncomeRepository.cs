using FTBackend.Core.Entities;

namespace FTBackend.Core.Interfaces;

public interface IActiveIncomeRepository
{
    Task<ActiveIncome?> GetByUserIdAsync(string userId);
    Task<ActiveIncome> UpsertAsync(ActiveIncome activeIncome);
}
