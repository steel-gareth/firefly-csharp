using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Recurrences;

/// <summary>
/// The type of the repetition. ndom means: the n-th weekday of the month, where
/// you can also specify which day of the week.
/// </summary>
[JsonConverter(typeof(RecurrenceRepetitionTypeConverter))]
public enum RecurrenceRepetitionType
{
    Daily,
    Weekly,
    Ndom,
    Monthly,
    Yearly,
}

sealed class RecurrenceRepetitionTypeConverter : JsonConverter<RecurrenceRepetitionType>
{
    public override RecurrenceRepetitionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => RecurrenceRepetitionType.Daily,
            "weekly" => RecurrenceRepetitionType.Weekly,
            "ndom" => RecurrenceRepetitionType.Ndom,
            "monthly" => RecurrenceRepetitionType.Monthly,
            "yearly" => RecurrenceRepetitionType.Yearly,
            _ => (RecurrenceRepetitionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecurrenceRepetitionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RecurrenceRepetitionType.Daily => "daily",
                RecurrenceRepetitionType.Weekly => "weekly",
                RecurrenceRepetitionType.Ndom => "ndom",
                RecurrenceRepetitionType.Monthly => "monthly",
                RecurrenceRepetitionType.Yearly => "yearly",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
