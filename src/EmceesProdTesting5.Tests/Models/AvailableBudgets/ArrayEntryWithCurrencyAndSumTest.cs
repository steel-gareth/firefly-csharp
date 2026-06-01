using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.AvailableBudgets;

namespace EmceesProdTesting5.Tests.Models.AvailableBudgets;

public class ArrayEntryWithCurrencyAndSumTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ArrayEntryWithCurrencyAndSum
        {
            CurrencyCode = "USD",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencySymbol = "$",
            Sum = "123.45",
        };

        string expectedCurrencyCode = "USD";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencySymbol = "$";
        string expectedSum = "123.45";

        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedSum, model.Sum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ArrayEntryWithCurrencyAndSum
        {
            CurrencyCode = "USD",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencySymbol = "$",
            Sum = "123.45",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ArrayEntryWithCurrencyAndSum>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ArrayEntryWithCurrencyAndSum
        {
            CurrencyCode = "USD",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencySymbol = "$",
            Sum = "123.45",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ArrayEntryWithCurrencyAndSum>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrencyCode = "USD";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencySymbol = "$";
        string expectedSum = "123.45";

        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedSum, deserialized.Sum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ArrayEntryWithCurrencyAndSum
        {
            CurrencyCode = "USD",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencySymbol = "$",
            Sum = "123.45",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ArrayEntryWithCurrencyAndSum { };

        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.Sum);
        Assert.False(model.RawData.ContainsKey("sum"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ArrayEntryWithCurrencyAndSum { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ArrayEntryWithCurrencyAndSum
        {
            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencySymbol = null,
            Sum = null,
        };

        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.Sum);
        Assert.False(model.RawData.ContainsKey("sum"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ArrayEntryWithCurrencyAndSum
        {
            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencySymbol = null,
            Sum = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ArrayEntryWithCurrencyAndSum
        {
            CurrencyCode = "USD",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencySymbol = "$",
            Sum = "123.45",
        };

        ArrayEntryWithCurrencyAndSum copied = new(model);

        Assert.Equal(model, copied);
    }
}
