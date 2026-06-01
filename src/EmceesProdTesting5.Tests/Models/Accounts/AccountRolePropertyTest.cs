using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Tests.Models.Accounts;

public class AccountRolePropertyTest : TestBase
{
    [Theory]
    [InlineData(AccountRoleProperty.DefaultAsset)]
    [InlineData(AccountRoleProperty.SharedAsset)]
    [InlineData(AccountRoleProperty.SavingAsset)]
    [InlineData(AccountRoleProperty.CcAsset)]
    [InlineData(AccountRoleProperty.CashWalletAsset)]
    public void Validation_Works(AccountRoleProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountRoleProperty> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountRoleProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountRoleProperty.DefaultAsset)]
    [InlineData(AccountRoleProperty.SharedAsset)]
    [InlineData(AccountRoleProperty.SavingAsset)]
    [InlineData(AccountRoleProperty.CcAsset)]
    [InlineData(AccountRoleProperty.CashWalletAsset)]
    public void SerializationRoundtrip_Works(AccountRoleProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountRoleProperty> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountRoleProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountRoleProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountRoleProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
