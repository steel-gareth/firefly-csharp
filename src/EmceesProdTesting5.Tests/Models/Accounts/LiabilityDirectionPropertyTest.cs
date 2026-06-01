using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Tests.Models.Accounts;

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
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
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
