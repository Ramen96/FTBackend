// src/FTBackend.Core/Entities/Account.cs
namespace FTBackend.Core.Entities;

public class Account
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;     // e.g. "Chase Checking"
    public AccountType Type { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Transaction> Transactions { get; set; } = [];
}

public enum AccountType { Checking, Savings, CreditCard, Investment, Cash }
