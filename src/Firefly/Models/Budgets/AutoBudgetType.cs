using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Budgets;

/// <summary>
/// The type of auto-budget that Firefly III must create.
/// </summary>
[JsonConverter(typeof(AutoBudgetTypeConverter))]
public enum AutoBudgetType
{
    Reset,
    Rollover,
    None,
}

sealed class AutoBudgetTypeConverter : JsonConverter<AutoBudgetType>
{
    public override AutoBudgetType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "reset" => AutoBudgetType.Reset,
            "rollover" => AutoBudgetType.Rollover,
            "none" => AutoBudgetType.None,
            _ => (AutoBudgetType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutoBudgetType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AutoBudgetType.Reset => "reset",
                AutoBudgetType.Rollover => "rollover",
                AutoBudgetType.None => "none",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
