using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;

namespace Firefly.Tests.Models.Accounts;

public class CreditCardTypePropertyTest : TestBase
{
    [Theory]
    [InlineData(CreditCardTypeProperty.MonthlyFull)]
    public void Validation_Works(CreditCardTypeProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditCardTypeProperty> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditCardTypeProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreditCardTypeProperty.MonthlyFull)]
    public void SerializationRoundtrip_Works(CreditCardTypeProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreditCardTypeProperty> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditCardTypeProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreditCardTypeProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CreditCardTypeProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
