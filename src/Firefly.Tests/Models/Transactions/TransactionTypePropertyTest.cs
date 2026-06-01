using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Transactions;

namespace Firefly.Tests.Models.Transactions;

public class TransactionTypePropertyTest : TestBase
{
    [Theory]
    [InlineData(TransactionTypeProperty.Withdrawal)]
    [InlineData(TransactionTypeProperty.Deposit)]
    [InlineData(TransactionTypeProperty.Transfer)]
    [InlineData(TransactionTypeProperty.Reconciliation)]
    [InlineData(TransactionTypeProperty.OpeningBalance)]
    public void Validation_Works(TransactionTypeProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionTypeProperty> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionTypeProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TransactionTypeProperty.Withdrawal)]
    [InlineData(TransactionTypeProperty.Deposit)]
    [InlineData(TransactionTypeProperty.Transfer)]
    [InlineData(TransactionTypeProperty.Reconciliation)]
    [InlineData(TransactionTypeProperty.OpeningBalance)]
    public void SerializationRoundtrip_Works(TransactionTypeProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionTypeProperty> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionTypeProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionTypeProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionTypeProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
