using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Tests.Models.Accounts;

public class TransactionTypeFilterTest : TestBase
{
    [Theory]
    [InlineData(TransactionTypeFilter.All)]
    [InlineData(TransactionTypeFilter.Withdrawal)]
    [InlineData(TransactionTypeFilter.Withdrawals)]
    [InlineData(TransactionTypeFilter.Expense)]
    [InlineData(TransactionTypeFilter.Deposit)]
    [InlineData(TransactionTypeFilter.Deposits)]
    [InlineData(TransactionTypeFilter.Income)]
    [InlineData(TransactionTypeFilter.Transfer)]
    [InlineData(TransactionTypeFilter.Transfers)]
    [InlineData(TransactionTypeFilter.OpeningBalance)]
    [InlineData(TransactionTypeFilter.Reconciliation)]
    [InlineData(TransactionTypeFilter.Special)]
    [InlineData(TransactionTypeFilter.Specials)]
    [InlineData(TransactionTypeFilter.Default)]
    public void Validation_Works(TransactionTypeFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionTypeFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionTypeFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TransactionTypeFilter.All)]
    [InlineData(TransactionTypeFilter.Withdrawal)]
    [InlineData(TransactionTypeFilter.Withdrawals)]
    [InlineData(TransactionTypeFilter.Expense)]
    [InlineData(TransactionTypeFilter.Deposit)]
    [InlineData(TransactionTypeFilter.Deposits)]
    [InlineData(TransactionTypeFilter.Income)]
    [InlineData(TransactionTypeFilter.Transfer)]
    [InlineData(TransactionTypeFilter.Transfers)]
    [InlineData(TransactionTypeFilter.OpeningBalance)]
    [InlineData(TransactionTypeFilter.Reconciliation)]
    [InlineData(TransactionTypeFilter.Special)]
    [InlineData(TransactionTypeFilter.Specials)]
    [InlineData(TransactionTypeFilter.Default)]
    public void SerializationRoundtrip_Works(TransactionTypeFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionTypeFilter> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionTypeFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionTypeFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionTypeFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
