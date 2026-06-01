using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Accounts;

[JsonConverter(typeof(TransactionTypeFilterConverter))]
public enum TransactionTypeFilter
{
    All,
    Withdrawal,
    Withdrawals,
    Expense,
    Deposit,
    Deposits,
    Income,
    Transfer,
    Transfers,
    OpeningBalance,
    Reconciliation,
    Special,
    Specials,
    Default,
}

sealed class TransactionTypeFilterConverter : JsonConverter<TransactionTypeFilter>
{
    public override TransactionTypeFilter Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => TransactionTypeFilter.All,
            "withdrawal" => TransactionTypeFilter.Withdrawal,
            "withdrawals" => TransactionTypeFilter.Withdrawals,
            "expense" => TransactionTypeFilter.Expense,
            "deposit" => TransactionTypeFilter.Deposit,
            "deposits" => TransactionTypeFilter.Deposits,
            "income" => TransactionTypeFilter.Income,
            "transfer" => TransactionTypeFilter.Transfer,
            "transfers" => TransactionTypeFilter.Transfers,
            "opening_balance" => TransactionTypeFilter.OpeningBalance,
            "reconciliation" => TransactionTypeFilter.Reconciliation,
            "special" => TransactionTypeFilter.Special,
            "specials" => TransactionTypeFilter.Specials,
            "default" => TransactionTypeFilter.Default,
            _ => (TransactionTypeFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionTypeFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionTypeFilter.All => "all",
                TransactionTypeFilter.Withdrawal => "withdrawal",
                TransactionTypeFilter.Withdrawals => "withdrawals",
                TransactionTypeFilter.Expense => "expense",
                TransactionTypeFilter.Deposit => "deposit",
                TransactionTypeFilter.Deposits => "deposits",
                TransactionTypeFilter.Income => "income",
                TransactionTypeFilter.Transfer => "transfer",
                TransactionTypeFilter.Transfers => "transfers",
                TransactionTypeFilter.OpeningBalance => "opening_balance",
                TransactionTypeFilter.Reconciliation => "reconciliation",
                TransactionTypeFilter.Special => "special",
                TransactionTypeFilter.Specials => "specials",
                TransactionTypeFilter.Default => "default",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
