// src/FTBackend.Core/DTOs/TransactionDto.cs
using FTBackend.Core.Entities;

namespace FTBackend.Core.DTOs;

public record TransactionDto(
    Guid Id,
    decimal Amount,
    string Description,
    string Category,
    TransactionType Type,
    DateTime CreatedAt
);

public record CreateTransactionRequest(
    decimal Amount,
    string Description,
    string Category,
    TransactionType Type,
    Guid AccountId
);

public record UpdateTransactionRequest(
    decimal? Amount,
    string? Description,
    string? Category,
    TransactionType? Type
);
