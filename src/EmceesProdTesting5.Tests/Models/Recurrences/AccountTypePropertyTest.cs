using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Recurrences;

namespace EmceesProdTesting5.Tests.Models.Recurrences;

public class AccountTypePropertyTest : TestBase
{
    [Theory]
    [InlineData(AccountTypeProperty.DefaultAccount)]
    [InlineData(AccountTypeProperty.CashAccount)]
    [InlineData(AccountTypeProperty.AssetAccount)]
    [InlineData(AccountTypeProperty.ExpenseAccount)]
    [InlineData(AccountTypeProperty.RevenueAccount)]
    [InlineData(AccountTypeProperty.InitialBalanceAccount)]
    [InlineData(AccountTypeProperty.BeneficiaryAccount)]
    [InlineData(AccountTypeProperty.ImportAccount)]
    [InlineData(AccountTypeProperty.ReconciliationAccount)]
    [InlineData(AccountTypeProperty.Loan)]
    [InlineData(AccountTypeProperty.Debt)]
    [InlineData(AccountTypeProperty.Mortgage)]
    public void Validation_Works(AccountTypeProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTypeProperty> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTypeProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountTypeProperty.DefaultAccount)]
    [InlineData(AccountTypeProperty.CashAccount)]
    [InlineData(AccountTypeProperty.AssetAccount)]
    [InlineData(AccountTypeProperty.ExpenseAccount)]
    [InlineData(AccountTypeProperty.RevenueAccount)]
    [InlineData(AccountTypeProperty.InitialBalanceAccount)]
    [InlineData(AccountTypeProperty.BeneficiaryAccount)]
    [InlineData(AccountTypeProperty.ImportAccount)]
    [InlineData(AccountTypeProperty.ReconciliationAccount)]
    [InlineData(AccountTypeProperty.Loan)]
    [InlineData(AccountTypeProperty.Debt)]
    [InlineData(AccountTypeProperty.Mortgage)]
    public void SerializationRoundtrip_Works(AccountTypeProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTypeProperty> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTypeProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTypeProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTypeProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
