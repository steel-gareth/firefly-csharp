using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;

namespace Firefly.Tests.Models.Accounts;

public class ShortAccountTypePropertyTest : TestBase
{
    [Theory]
    [InlineData(ShortAccountTypeProperty.Asset)]
    [InlineData(ShortAccountTypeProperty.Expense)]
    [InlineData(ShortAccountTypeProperty.Import)]
    [InlineData(ShortAccountTypeProperty.Revenue)]
    [InlineData(ShortAccountTypeProperty.Cash)]
    [InlineData(ShortAccountTypeProperty.Liability)]
    [InlineData(ShortAccountTypeProperty.Liabilities)]
    [InlineData(ShortAccountTypeProperty.InitialBalance)]
    [InlineData(ShortAccountTypeProperty.Reconciliation)]
    public void Validation_Works(ShortAccountTypeProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ShortAccountTypeProperty> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ShortAccountTypeProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ShortAccountTypeProperty.Asset)]
    [InlineData(ShortAccountTypeProperty.Expense)]
    [InlineData(ShortAccountTypeProperty.Import)]
    [InlineData(ShortAccountTypeProperty.Revenue)]
    [InlineData(ShortAccountTypeProperty.Cash)]
    [InlineData(ShortAccountTypeProperty.Liability)]
    [InlineData(ShortAccountTypeProperty.Liabilities)]
    [InlineData(ShortAccountTypeProperty.InitialBalance)]
    [InlineData(ShortAccountTypeProperty.Reconciliation)]
    public void SerializationRoundtrip_Works(ShortAccountTypeProperty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ShortAccountTypeProperty> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ShortAccountTypeProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ShortAccountTypeProperty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ShortAccountTypeProperty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
