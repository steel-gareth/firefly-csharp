using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Accounts;

/// <summary>
/// Is only mandatory when the type is asset.
/// </summary>
[JsonConverter(typeof(AccountRolePropertyConverter))]
public enum AccountRoleProperty
{
    DefaultAsset,
    SharedAsset,
    SavingAsset,
    CcAsset,
    CashWalletAsset,
}

sealed class AccountRolePropertyConverter : JsonConverter<AccountRoleProperty>
{
    public override AccountRoleProperty Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "defaultAsset" => AccountRoleProperty.DefaultAsset,
            "sharedAsset" => AccountRoleProperty.SharedAsset,
            "savingAsset" => AccountRoleProperty.SavingAsset,
            "ccAsset" => AccountRoleProperty.CcAsset,
            "cashWalletAsset" => AccountRoleProperty.CashWalletAsset,
            _ => (AccountRoleProperty)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountRoleProperty value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountRoleProperty.DefaultAsset => "defaultAsset",
                AccountRoleProperty.SharedAsset => "sharedAsset",
                AccountRoleProperty.SavingAsset => "savingAsset",
                AccountRoleProperty.CcAsset => "ccAsset",
                AccountRoleProperty.CashWalletAsset => "cashWalletAsset",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
