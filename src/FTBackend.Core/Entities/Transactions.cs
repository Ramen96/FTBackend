// src/FTBackend.Core/Entities/Transaction.cs
namespace FTBackend.Core.Entities;

public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;  // Clerk user ID
    public decimal Amount { get; set; }                  // decimal, never float for money
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public TransactionType Type { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public enum TransactionType { Income, Expense }
