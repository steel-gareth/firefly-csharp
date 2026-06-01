using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Attachments;

/// <summary>
/// The object class to which the attachment must be linked.
/// </summary>
[JsonConverter(typeof(AttachableTypeConverter))]
public enum AttachableType
{
    Account,
    Budget,
    Bill,
    TransactionJournal,
    PiggyBank,
    Tag,
}

sealed class AttachableTypeConverter : JsonConverter<AttachableType>
{
    public override AttachableType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Account" => AttachableType.Account,
            "Budget" => AttachableType.Budget,
            "Bill" => AttachableType.Bill,
            "TransactionJournal" => AttachableType.TransactionJournal,
            "PiggyBank" => AttachableType.PiggyBank,
            "Tag" => AttachableType.Tag,
            _ => (AttachableType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AttachableType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AttachableType.Account => "Account",
                AttachableType.Budget => "Budget",
                AttachableType.Bill => "Bill",
                AttachableType.TransactionJournal => "TransactionJournal",
                AttachableType.PiggyBank => "PiggyBank",
                AttachableType.Tag => "Tag",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
