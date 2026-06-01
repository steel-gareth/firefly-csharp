using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Budgets;

namespace Firefly.Tests.Models.Budgets;

public class AutoBudgetTypeTest : TestBase
{
    [Theory]
    [InlineData(AutoBudgetType.Reset)]
    [InlineData(AutoBudgetType.Rollover)]
    [InlineData(AutoBudgetType.None)]
    public void Validation_Works(AutoBudgetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutoBudgetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutoBudgetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AutoBudgetType.Reset)]
    [InlineData(AutoBudgetType.Rollover)]
    [InlineData(AutoBudgetType.None)]
    public void SerializationRoundtrip_Works(AutoBudgetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutoBudgetType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutoBudgetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutoBudgetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutoBudgetType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
