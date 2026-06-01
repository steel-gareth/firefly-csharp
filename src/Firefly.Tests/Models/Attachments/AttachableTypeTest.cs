using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Attachments;

namespace Firefly.Tests.Models.Attachments;

public class AttachableTypeTest : TestBase
{
    [Theory]
    [InlineData(AttachableType.Account)]
    [InlineData(AttachableType.Budget)]
    [InlineData(AttachableType.Bill)]
    [InlineData(AttachableType.TransactionJournal)]
    [InlineData(AttachableType.PiggyBank)]
    [InlineData(AttachableType.Tag)]
    public void Validation_Works(AttachableType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AttachableType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AttachableType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AttachableType.Account)]
    [InlineData(AttachableType.Budget)]
    [InlineData(AttachableType.Bill)]
    [InlineData(AttachableType.TransactionJournal)]
    [InlineData(AttachableType.PiggyBank)]
    [InlineData(AttachableType.Tag)]
    public void SerializationRoundtrip_Works(AttachableType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AttachableType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AttachableType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AttachableType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AttachableType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
