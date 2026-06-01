using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Accounts;

/// <summary>
/// 'credit' indicates somebody owes you the liability. 'debit' Indicates you owe
/// this debt yourself. Works only for liabilities.
/// </summary>
[JsonConverter(typeof(LiabilityDirectionPropertyConverter))]
public enum LiabilityDirectionProperty
{
    Credit,
    Debit,
}

sealed class LiabilityDirectionPropertyConverter : JsonConverter<LiabilityDirectionProperty>
{
    public override LiabilityDirectionProperty Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit" => LiabilityDirectionProperty.Credit,
            "debit" => LiabilityDirectionProperty.Debit,
            _ => (LiabilityDirectionProperty)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LiabilityDirectionProperty value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LiabilityDirectionProperty.Credit => "credit",
                LiabilityDirectionProperty.Debit => "debit",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
