using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Insight.Expense;

namespace EmceesProdTesting5.Tests.Models.Insight.Expense;

public class InsightGroupEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InsightGroupEntry
        {
            ID = "123",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "-123.45",
            DifferenceFloat = -123.45,
            Name = "Land lord",
        };

        string expectedID = "123";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "5";
        string expectedDifference = "-123.45";
        double expectedDifferenceFloat = -123.45;
        string expectedName = "Land lord";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedDifferenceFloat, model.DifferenceFloat);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InsightGroupEntry
        {
            ID = "123",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "-123.45",
            DifferenceFloat = -123.45,
            Name = "Land lord",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InsightGroupEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InsightGroupEntry
        {
            ID = "123",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "-123.45",
            DifferenceFloat = -123.45,
            Name = "Land lord",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InsightGroupEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "123";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "5";
        string expectedDifference = "-123.45";
        double expectedDifferenceFloat = -123.45;
        string expectedName = "Land lord";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedDifferenceFloat, deserialized.DifferenceFloat);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InsightGroupEntry
        {
            ID = "123",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "-123.45",
            DifferenceFloat = -123.45,
            Name = "Land lord",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InsightGroupEntry { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.DifferenceFloat);
        Assert.False(model.RawData.ContainsKey("difference_float"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InsightGroupEntry { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InsightGroupEntry
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CurrencyCode = null,
            CurrencyID = null,
            Difference = null,
            DifferenceFloat = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.Difference);
        Assert.False(model.RawData.ContainsKey("difference"));
        Assert.Null(model.DifferenceFloat);
        Assert.False(model.RawData.ContainsKey("difference_float"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InsightGroupEntry
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CurrencyCode = null,
            CurrencyID = null,
            Difference = null,
            DifferenceFloat = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InsightGroupEntry
        {
            ID = "123",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "-123.45",
            DifferenceFloat = -123.45,
            Name = "Land lord",
        };

        InsightGroupEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}
