using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Rules;

namespace EmceesProdTesting5.Tests.Models.Rules;

public class RuleTriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(RuleTriggerType.StoreJournal)]
    [InlineData(RuleTriggerType.UpdateJournal)]
    [InlineData(RuleTriggerType.ManualActivation)]
    public void Validation_Works(RuleTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RuleTriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RuleTriggerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RuleTriggerType.StoreJournal)]
    [InlineData(RuleTriggerType.UpdateJournal)]
    [InlineData(RuleTriggerType.ManualActivation)]
    public void SerializationRoundtrip_Works(RuleTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RuleTriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RuleTriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RuleTriggerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RuleTriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
