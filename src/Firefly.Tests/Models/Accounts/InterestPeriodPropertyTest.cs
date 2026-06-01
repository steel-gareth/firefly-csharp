using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;

namespace Firefly.Tests.Models.Accounts;

public class InterestPeriodPropertyTest : TestBase
{
    [Theory]
    [InlineData(InterestPeriodProperty.Daily)]
    [InlineData(InterestPeriodProperty.Weekly)]
    [InlineData(InterestPeriodProperty.Monthly)]
    [InlineData(InterestPeriodProperty.Quarterly)]
    [InlineData(InterestPeriodProperty.HalfYear)]
    [InlineData(InterestPeriodProperty.Yearly)]
    public void Validation_Works(InterestPeriodProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InterestPeriodProperty> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InterestPeriodProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InterestPeriodProperty.Daily)]
    [InlineData(InterestPeriodProperty.Weekly)]
    [InlineData(InterestPeriodProperty.Monthly)]
    [InlineData(InterestPeriodProperty.Quarterly)]
    [InlineData(InterestPeriodProperty.HalfYear)]
    [InlineData(InterestPeriodProperty.Yearly)]
    public void SerializationRoundtrip_Works(InterestPeriodProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InterestPeriodProperty> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InterestPeriodProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InterestPeriodProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InterestPeriodProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
