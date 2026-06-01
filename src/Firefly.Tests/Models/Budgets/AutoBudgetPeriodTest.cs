using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Budgets;

namespace Firefly.Tests.Models.Budgets;

public class AutoBudgetPeriodTest : TestBase
{
    [Theory]
    [InlineData(AutoBudgetPeriod.Daily)]
    [InlineData(AutoBudgetPeriod.Weekly)]
    [InlineData(AutoBudgetPeriod.Monthly)]
    [InlineData(AutoBudgetPeriod.Quarterly)]
    [InlineData(AutoBudgetPeriod.HalfYear)]
    [InlineData(AutoBudgetPeriod.Yearly)]
    public void Validation_Works(AutoBudgetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutoBudgetPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutoBudgetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AutoBudgetPeriod.Daily)]
    [InlineData(AutoBudgetPeriod.Weekly)]
    [InlineData(AutoBudgetPeriod.Monthly)]
    [InlineData(AutoBudgetPeriod.Quarterly)]
    [InlineData(AutoBudgetPeriod.HalfYear)]
    [InlineData(AutoBudgetPeriod.Yearly)]
    public void SerializationRoundtrip_Works(AutoBudgetPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutoBudgetPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutoBudgetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutoBudgetPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutoBudgetPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
