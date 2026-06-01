using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Budgets;

/// <summary>
/// Period for the auto budget
/// </summary>
[JsonConverter(typeof(AutoBudgetPeriodConverter))]
public enum AutoBudgetPeriod
{
    Daily,
    Weekly,
    Monthly,
    Quarterly,
    HalfYear,
    Yearly,
}

sealed class AutoBudgetPeriodConverter : JsonConverter<AutoBudgetPeriod>
{
    public override AutoBudgetPeriod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => AutoBudgetPeriod.Daily,
            "weekly" => AutoBudgetPeriod.Weekly,
            "monthly" => AutoBudgetPeriod.Monthly,
            "quarterly" => AutoBudgetPeriod.Quarterly,
            "half-year" => AutoBudgetPeriod.HalfYear,
            "yearly" => AutoBudgetPeriod.Yearly,
            _ => (AutoBudgetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutoBudgetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AutoBudgetPeriod.Daily => "daily",
                AutoBudgetPeriod.Weekly => "weekly",
                AutoBudgetPeriod.Monthly => "monthly",
                AutoBudgetPeriod.Quarterly => "quarterly",
                AutoBudgetPeriod.HalfYear => "half-year",
                AutoBudgetPeriod.Yearly => "yearly",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
