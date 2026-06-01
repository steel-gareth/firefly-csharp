using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Rules;

/// <summary>
/// Which action is necessary for the rule to fire? Use either store-journal, update-journal
/// or manual-activation.
/// </summary>
[JsonConverter(typeof(RuleTriggerTypeConverter))]
public enum RuleTriggerType
{
    StoreJournal,
    UpdateJournal,
    ManualActivation,
}

sealed class RuleTriggerTypeConverter : JsonConverter<RuleTriggerType>
{
    public override RuleTriggerType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "store-journal" => RuleTriggerType.StoreJournal,
            "update-journal" => RuleTriggerType.UpdateJournal,
            "manual-activation" => RuleTriggerType.ManualActivation,
            _ => (RuleTriggerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RuleTriggerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RuleTriggerType.StoreJournal => "store-journal",
                RuleTriggerType.UpdateJournal => "update-journal",
                RuleTriggerType.ManualActivation => "manual-activation",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
