using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Accounts;

/// <summary>
/// Mandatory when type is liability. Period over which the interest is calculated.
/// </summary>
[JsonConverter(typeof(InterestPeriodPropertyConverter))]
public enum InterestPeriodProperty
{
    Daily,
    Weekly,
    Monthly,
    Quarterly,
    HalfYear,
    Yearly,
}

sealed class InterestPeriodPropertyConverter : JsonConverter<InterestPeriodProperty>
{
    public override InterestPeriodProperty Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => InterestPeriodProperty.Daily,
            "weekly" => InterestPeriodProperty.Weekly,
            "monthly" => InterestPeriodProperty.Monthly,
            "quarterly" => InterestPeriodProperty.Quarterly,
            "half-year" => InterestPeriodProperty.HalfYear,
            "yearly" => InterestPeriodProperty.Yearly,
            _ => (InterestPeriodProperty)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InterestPeriodProperty value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InterestPeriodProperty.Daily => "daily",
                InterestPeriodProperty.Weekly => "weekly",
                InterestPeriodProperty.Monthly => "monthly",
                InterestPeriodProperty.Quarterly => "quarterly",
                InterestPeriodProperty.HalfYear => "half-year",
                InterestPeriodProperty.Yearly => "yearly",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
