using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Insight.Expense;

namespace Firefly.Tests.Models.Insight.Expense;

public class InsightTotalEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InsightTotalEntry
        {
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "123.45",
            DifferenceFloat = 123.45,
        };

        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "5";
        string expectedDifference = "123.45";
        double expectedDifferenceFloat = 123.45;

        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedDifferenceFloat, model.DifferenceFloat);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InsightTotalEntry
        {
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "123.45",
            DifferenceFloat = 123.45,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InsightTotalEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InsightTotalEntry
        {
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "123.45",
            DifferenceFloat = 123.45,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InsightTotalEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "5";
        string expectedDifference = "123.45";
        double expectedDifferenceFloat = 123.45;

        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedDifferenceFloat, deserialized.DifferenceFloat);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InsightTotalEntry
        {
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "123.45",
            DifferenceFloat = 123.45,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InsightTotalEntry { };

        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.DifferenceFloat);
        Assert.False(model.RawData.ContainsKey("difference_float"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InsightTotalEntry { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InsightTotalEntry
        {
            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyID = null,
            Difference = null,
            DifferenceFloat = null,
        };

        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.DifferenceFloat);
        Assert.False(model.RawData.ContainsKey("difference_float"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InsightTotalEntry
        {
            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyID = null,
            Difference = null,
            DifferenceFloat = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InsightTotalEntry
        {
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "123.45",
            DifferenceFloat = 123.45,
        };

        InsightTotalEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}
