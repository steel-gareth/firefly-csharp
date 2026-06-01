using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Recurrences;

[JsonConverter(typeof(RecurrenceTransactionTypeConverter))]
public enum RecurrenceTransactionType
{
    Withdrawal,
    Transfer,
    Deposit,
}

sealed class RecurrenceTransactionTypeConverter : JsonConverter<RecurrenceTransactionType>
{
    public override RecurrenceTransactionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "withdrawal" => RecurrenceTransactionType.Withdrawal,
            "transfer" => RecurrenceTransactionType.Transfer,
            "deposit" => RecurrenceTransactionType.Deposit,
            _ => (RecurrenceTransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecurrenceTransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RecurrenceTransactionType.Withdrawal => "withdrawal",
                RecurrenceTransactionType.Transfer => "transfer",
                RecurrenceTransactionType.Deposit => "deposit",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
