using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Exceptions;

namespace Firefly.Models.Accounts;

/// <summary>
/// Mandatory when type is liability. Specifies the exact type.
/// </summary>
[JsonConverter(typeof(LiabilityTypePropertyConverter))]
public enum LiabilityTypeProperty
{
    Loan,
    Debt,
    Mortgage,
}

sealed class LiabilityTypePropertyConverter : JsonConverter<LiabilityTypeProperty>
{
    public override LiabilityTypeProperty Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "loan" => LiabilityTypeProperty.Loan,
            "debt" => LiabilityTypeProperty.Debt,
            "mortgage" => LiabilityTypeProperty.Mortgage,
            _ => (LiabilityTypeProperty)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LiabilityTypeProperty value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LiabilityTypeProperty.Loan => "loan",
                LiabilityTypeProperty.Debt => "debt",
                LiabilityTypeProperty.Mortgage => "mortgage",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
