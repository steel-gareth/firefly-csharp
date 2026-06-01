using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Chart.Account;

namespace EmceesProdTesting5.Tests.Models.Chart.Account;

public class ChartDataPointTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChartDataPoint { Key = "value" };

        string expectedKey = "value";

        Assert.Equal(expectedKey, model.Key);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChartDataPoint { Key = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChartDataPoint>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChartDataPoint { Key = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChartDataPoint>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKey = "value";

        Assert.Equal(expectedKey, deserialized.Key);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChartDataPoint { Key = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChartDataPoint { };

        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChartDataPoint { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ChartDataPoint
        {
            // Null should be interpreted as omitted for these properties
            Key = null,
        };

        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChartDataPoint
        {
            // Null should be interpreted as omitted for these properties
            Key = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChartDataPoint { Key = "value" };

        ChartDataPoint copied = new(model);

        Assert.Equal(model, copied);
    }
}
