using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Transactions;

[JsonConverter(typeof(TransactionTypePropertyConverter))]
public enum TransactionTypeProperty
{
    Withdrawal,
    Deposit,
    Transfer,
    Reconciliation,
    OpeningBalance,
}

sealed class TransactionTypePropertyConverter : JsonConverter<TransactionTypeProperty>
{
    public override TransactionTypeProperty Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "withdrawal" => TransactionTypeProperty.Withdrawal,
            "deposit" => TransactionTypeProperty.Deposit,
            "transfer" => TransactionTypeProperty.Transfer,
            "reconciliation" => TransactionTypeProperty.Reconciliation,
            "opening balance" => TransactionTypeProperty.OpeningBalance,
            _ => (TransactionTypeProperty)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransactionTypeProperty value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransactionTypeProperty.Withdrawal => "withdrawal",
                TransactionTypeProperty.Deposit => "deposit",
                TransactionTypeProperty.Transfer => "transfer",
                TransactionTypeProperty.Reconciliation => "reconciliation",
                TransactionTypeProperty.OpeningBalance => "opening balance",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
