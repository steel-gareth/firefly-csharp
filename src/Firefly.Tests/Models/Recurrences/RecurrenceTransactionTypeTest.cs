using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Recurrences;

namespace Firefly.Tests.Models.Recurrences;

public class RecurrenceTransactionTypeTest : TestBase
{
    [Theory]
    [InlineData(RecurrenceTransactionType.Withdrawal)]
    [InlineData(RecurrenceTransactionType.Transfer)]
    [InlineData(RecurrenceTransactionType.Deposit)]
    public void Validation_Works(RecurrenceTransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RecurrenceTransactionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RecurrenceTransactionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RecurrenceTransactionType.Withdrawal)]
    [InlineData(RecurrenceTransactionType.Transfer)]
    [InlineData(RecurrenceTransactionType.Deposit)]
    public void SerializationRoundtrip_Works(RecurrenceTransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RecurrenceTransactionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RecurrenceTransactionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RecurrenceTransactionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RecurrenceTransactionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
