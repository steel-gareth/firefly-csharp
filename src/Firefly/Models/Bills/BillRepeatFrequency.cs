using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Bills;

/// <summary>
/// How often the bill must be paid.
/// </summary>
[JsonConverter(typeof(BillRepeatFrequencyConverter))]
public enum BillRepeatFrequency
{
    Weekly,
    Monthly,
    Quarterly,
    HalfYear,
    Yearly,
}

sealed class BillRepeatFrequencyConverter : JsonConverter<BillRepeatFrequency>
{
    public override BillRepeatFrequency Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "weekly" => BillRepeatFrequency.Weekly,
            "monthly" => BillRepeatFrequency.Monthly,
            "quarterly" => BillRepeatFrequency.Quarterly,
            "half-year" => BillRepeatFrequency.HalfYear,
            "yearly" => BillRepeatFrequency.Yearly,
            _ => (BillRepeatFrequency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillRepeatFrequency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BillRepeatFrequency.Weekly => "weekly",
                BillRepeatFrequency.Monthly => "monthly",
                BillRepeatFrequency.Quarterly => "quarterly",
                BillRepeatFrequency.HalfYear => "half-year",
                BillRepeatFrequency.Yearly => "yearly",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
