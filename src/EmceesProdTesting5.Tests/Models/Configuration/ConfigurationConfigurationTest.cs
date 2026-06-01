using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Configuration;

namespace EmceesProdTesting5.Tests.Models.Configuration;

public class ConfigurationConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConfigurationConfiguration
        {
            Editable = true,
            Title = ConfigValueFilter.ConfigurationIsDemoSite,
            Value = true,
        };

        bool expectedEditable = true;
        ApiEnum<string, ConfigValueFilter> expectedTitle =
            ConfigValueFilter.ConfigurationIsDemoSite;
        PolymorphicProperty expectedValue = true;

        Assert.Equal(expectedEditable, model.Editable);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConfigurationConfiguration
        {
            Editable = true,
            Title = ConfigValueFilter.ConfigurationIsDemoSite,
            Value = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConfigurationConfiguration
        {
            Editable = true,
            Title = ConfigValueFilter.ConfigurationIsDemoSite,
            Value = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEditable = true;
        ApiEnum<string, ConfigValueFilter> expectedTitle =
            ConfigValueFilter.ConfigurationIsDemoSite;
        PolymorphicProperty expectedValue = true;

        Assert.Equal(expectedEditable, deserialized.Editable);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConfigurationConfiguration
        {
            Editable = true,
            Title = ConfigValueFilter.ConfigurationIsDemoSite,
            Value = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConfigurationConfiguration
        {
            Editable = true,
            Title = ConfigValueFilter.ConfigurationIsDemoSite,
            Value = true,
        };

        ConfigurationConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}
