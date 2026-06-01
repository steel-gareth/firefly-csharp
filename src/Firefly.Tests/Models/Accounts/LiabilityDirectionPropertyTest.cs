using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;

namespace Firefly.Tests.Models.Accounts;

public class LiabilityDirectionPropertyTest : TestBase
{
    [Theory]
    [InlineData(LiabilityDirectionProperty.Credit)]
    [InlineData(LiabilityDirectionProperty.Debit)]
    public void Validation_Works(LiabilityDirectionProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LiabilityDirectionProperty> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LiabilityDirectionProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LiabilityDirectionProperty.Credit)]
    [InlineData(LiabilityDirectionProperty.Debit)]
    public void SerializationRoundtrip_Works(LiabilityDirectionProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LiabilityDirectionProperty> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LiabilityDirectionProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LiabilityDirectionProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LiabilityDirectionProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
