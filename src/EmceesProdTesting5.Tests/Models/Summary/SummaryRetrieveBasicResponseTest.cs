using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Summary;

namespace EmceesProdTesting5.Tests.Models.Summary;

public class SummaryRetrieveBasicResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SummaryRetrieveBasicResponse
        {
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencySymbol = "$",
            Key = "balance-in-EUR",
            LocalIcon = "balance-scale",
            MonetaryValue = 123.45,
            NoAvailableBudgets = false,
            SubTitle = "$20 + $-40",
            Title = "Balance ($)",
            ValueParsed = "$ 12.45",
        };

        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencySymbol = "$";
        string expectedKey = "balance-in-EUR";
        string expectedLocalIcon = "balance-scale";
        double expectedMonetaryValue = 123.45;
        bool expectedNoAvailableBudgets = false;
        string expectedSubTitle = "$20 + $-40";
        string expectedTitle = "Balance ($)";
        string expectedValueParsed = "$ 12.45";

        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedLocalIcon, model.LocalIcon);
        Assert.Equal(expectedMonetaryValue, model.MonetaryValue);
        Assert.Equal(expectedNoAvailableBudgets, model.NoAvailableBudgets);
        Assert.Equal(expectedSubTitle, model.SubTitle);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedValueParsed, model.ValueParsed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SummaryRetrieveBasicResponse
        {
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencySymbol = "$",
            Key = "balance-in-EUR",
            LocalIcon = "balance-scale",
            MonetaryValue = 123.45,
            NoAvailableBudgets = false,
            SubTitle = "$20 + $-40",
            Title = "Balance ($)",
            ValueParsed = "$ 12.45",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SummaryRetrieveBasicResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SummaryRetrieveBasicResponse
        {
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencySymbol = "$",
            Key = "balance-in-EUR",
            LocalIcon = "balance-scale",
            MonetaryValue = 123.45,
            NoAvailableBudgets = false,
            SubTitle = "$20 + $-40",
            Title = "Balance ($)",
            ValueParsed = "$ 12.45",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SummaryRetrieveBasicResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencySymbol = "$";
        string expectedKey = "balance-in-EUR";
        string expectedLocalIcon = "balance-scale";
        double expectedMonetaryValue = 123.45;
        bool expectedNoAvailableBudgets = false;
        string expectedSubTitle = "$20 + $-40";
        string expectedTitle = "Balance ($)";
        string expectedValueParsed = "$ 12.45";

        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedLocalIcon, deserialized.LocalIcon);
        Assert.Equal(expectedMonetaryValue, deserialized.MonetaryValue);
        Assert.Equal(expectedNoAvailableBudgets, deserialized.NoAvailableBudgets);
        Assert.Equal(expectedSubTitle, deserialized.SubTitle);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedValueParsed, deserialized.ValueParsed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SummaryRetrieveBasicResponse
        {
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencySymbol = "$",
            Key = "balance-in-EUR",
            LocalIcon = "balance-scale",
            MonetaryValue = 123.45,
            NoAvailableBudgets = false,
            SubTitle = "$20 + $-40",
            Title = "Balance ($)",
            ValueParsed = "$ 12.45",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SummaryRetrieveBasicResponse { };

        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.LocalIcon);
        Assert.False(model.RawData.ContainsKey("local_icon"));
        Assert.Null(model.MonetaryValue);
        Assert.False(model.RawData.ContainsKey("monetary_value"));
        Assert.Null(model.NoAvailableBudgets);
        Assert.False(model.RawData.ContainsKey("no_available_budgets"));
        Assert.Null(model.SubTitle);
        Assert.False(model.RawData.ContainsKey("sub_title"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.ValueParsed);
        Assert.False(model.RawData.ContainsKey("value_parsed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SummaryRetrieveBasicResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SummaryRetrieveBasicResponse
        {
            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencySymbol = null,
            Key = null,
            LocalIcon = null,
            MonetaryValue = null,
            NoAvailableBudgets = null,
            SubTitle = null,
            Title = null,
            ValueParsed = null,
        };

        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.LocalIcon);
        Assert.False(model.RawData.ContainsKey("local_icon"));
        Assert.Null(model.MonetaryValue);
        Assert.False(model.RawData.ContainsKey("monetary_value"));
        Assert.Null(model.NoAvailableBudgets);
        Assert.False(model.RawData.ContainsKey("no_available_budgets"));
        Assert.Null(model.SubTitle);
        Assert.False(model.RawData.ContainsKey("sub_title"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.ValueParsed);
        Assert.False(model.RawData.ContainsKey("value_parsed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SummaryRetrieveBasicResponse
        {
            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencySymbol = null,
            Key = null,
            LocalIcon = null,
            MonetaryValue = null,
            NoAvailableBudgets = null,
            SubTitle = null,
            Title = null,
            ValueParsed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SummaryRetrieveBasicResponse
        {
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencySymbol = "$",
            Key = "balance-in-EUR",
            LocalIcon = "balance-scale",
            MonetaryValue = 123.45,
            NoAvailableBudgets = false,
            SubTitle = "$20 + $-40",
            Title = "Balance ($)",
            ValueParsed = "$ 12.45",
        };

        SummaryRetrieveBasicResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
