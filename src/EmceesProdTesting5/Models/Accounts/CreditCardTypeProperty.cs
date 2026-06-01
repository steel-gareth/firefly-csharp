using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Accounts;

/// <summary>
/// Mandatory when the account_role is ccAsset. Can only be monthlyFull or null.
/// </summary>
[JsonConverter(typeof(CreditCardTypePropertyConverter))]
public enum CreditCardTypeProperty
{
    MonthlyFull,
}

sealed class CreditCardTypePropertyConverter : JsonConverter<CreditCardTypeProperty>
{
    public override CreditCardTypeProperty Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "monthlyFull" => CreditCardTypeProperty.MonthlyFull,
            _ => (CreditCardTypeProperty)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditCardTypeProperty value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditCardTypeProperty.MonthlyFull => "monthlyFull",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
