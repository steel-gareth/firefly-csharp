using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Accounts;

/// <summary>
/// Can only be one one these account types. import, initial-balance and reconciliation
/// cannot be set manually.
/// </summary>
[JsonConverter(typeof(ShortAccountTypePropertyConverter))]
public enum ShortAccountTypeProperty
{
    Asset,
    Expense,
    Import,
    Revenue,
    Cash,
    Liability,
    Liabilities,
    InitialBalance,
    Reconciliation,
}

sealed class ShortAccountTypePropertyConverter : JsonConverter<ShortAccountTypeProperty>
{
    public override ShortAccountTypeProperty Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asset" => ShortAccountTypeProperty.Asset,
            "expense" => ShortAccountTypeProperty.Expense,
            "import" => ShortAccountTypeProperty.Import,
            "revenue" => ShortAccountTypeProperty.Revenue,
            "cash" => ShortAccountTypeProperty.Cash,
            "liability" => ShortAccountTypeProperty.Liability,
            "liabilities" => ShortAccountTypeProperty.Liabilities,
            "initial-balance" => ShortAccountTypeProperty.InitialBalance,
            "reconciliation" => ShortAccountTypeProperty.Reconciliation,
            _ => (ShortAccountTypeProperty)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShortAccountTypeProperty value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShortAccountTypeProperty.Asset => "asset",
                ShortAccountTypeProperty.Expense => "expense",
                ShortAccountTypeProperty.Import => "import",
                ShortAccountTypeProperty.Revenue => "revenue",
                ShortAccountTypeProperty.Cash => "cash",
                ShortAccountTypeProperty.Liability => "liability",
                ShortAccountTypeProperty.Liabilities => "liabilities",
                ShortAccountTypeProperty.InitialBalance => "initial-balance",
                ShortAccountTypeProperty.Reconciliation => "reconciliation",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
