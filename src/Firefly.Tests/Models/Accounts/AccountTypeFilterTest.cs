using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;

namespace Firefly.Tests.Models.Accounts;

public class AccountTypeFilterTest : TestBase
{
    [Theory]
    [InlineData(AccountTypeFilter.All)]
    [InlineData(AccountTypeFilter.Asset)]
    [InlineData(AccountTypeFilter.Cash)]
    [InlineData(AccountTypeFilter.Expense)]
    [InlineData(AccountTypeFilter.Revenue)]
    [InlineData(AccountTypeFilter.Special)]
    [InlineData(AccountTypeFilter.Hidden)]
    [InlineData(AccountTypeFilter.Liability)]
    [InlineData(AccountTypeFilter.Liabilities)]
    [InlineData(AccountTypeFilter.DefaultAccount)]
    [InlineData(AccountTypeFilter.CashAccount)]
    [InlineData(AccountTypeFilter.AssetAccount)]
    [InlineData(AccountTypeFilter.ExpenseAccount)]
    [InlineData(AccountTypeFilter.RevenueAccount)]
    [InlineData(AccountTypeFilter.InitialBalanceAccount)]
    [InlineData(AccountTypeFilter.BeneficiaryAccount)]
    [InlineData(AccountTypeFilter.ImportAccount)]
    [InlineData(AccountTypeFilter.ReconciliationAccount)]
    [InlineData(AccountTypeFilter.Loan)]
    [InlineData(AccountTypeFilter.Debt)]
    [InlineData(AccountTypeFilter.Mortgage)]
    public void Validation_Works(AccountTypeFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTypeFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTypeFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountTypeFilter.All)]
    [InlineData(AccountTypeFilter.Asset)]
    [InlineData(AccountTypeFilter.Cash)]
    [InlineData(AccountTypeFilter.Expense)]
    [InlineData(AccountTypeFilter.Revenue)]
    [InlineData(AccountTypeFilter.Special)]
    [InlineData(AccountTypeFilter.Hidden)]
    [InlineData(AccountTypeFilter.Liability)]
    [InlineData(AccountTypeFilter.Liabilities)]
    [InlineData(AccountTypeFilter.DefaultAccount)]
    [InlineData(AccountTypeFilter.CashAccount)]
    [InlineData(AccountTypeFilter.AssetAccount)]
    [InlineData(AccountTypeFilter.ExpenseAccount)]
    [InlineData(AccountTypeFilter.RevenueAccount)]
    [InlineData(AccountTypeFilter.InitialBalanceAccount)]
    [InlineData(AccountTypeFilter.BeneficiaryAccount)]
    [InlineData(AccountTypeFilter.ImportAccount)]
    [InlineData(AccountTypeFilter.ReconciliationAccount)]
    [InlineData(AccountTypeFilter.Loan)]
    [InlineData(AccountTypeFilter.Debt)]
    [InlineData(AccountTypeFilter.Mortgage)]
    public void SerializationRoundtrip_Works(AccountTypeFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTypeFilter> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTypeFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTypeFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTypeFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
