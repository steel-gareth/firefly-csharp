using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Insight.Transfer;

namespace Firefly.Tests.Models.Insight.Transfer;

public class TransferListByAssetAccountResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TransferListByAssetAccountResponse
        {
            ID = "123",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "-123.45",
            DifferenceFloat = -123.45,
            In = "123.45",
            InFloat = 123.45,
            Name = "Land lord",
            Out = "123.45",
            OutFloat = 123.45,
        };

        string expectedID = "123";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "5";
        string expectedDifference = "-123.45";
        double expectedDifferenceFloat = -123.45;
        string expectedIn = "123.45";
        double expectedInFloat = 123.45;
        string expectedName = "Land lord";
        string expectedOut = "123.45";
        double expectedOutFloat = 123.45;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedDifference, model.Difference);
        Assert.Equal(expectedDifferenceFloat, model.DifferenceFloat);
        Assert.Equal(expectedIn, model.In);
        Assert.Equal(expectedInFloat, model.InFloat);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOut, model.Out);
        Assert.Equal(expectedOutFloat, model.OutFloat);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TransferListByAssetAccountResponse
        {
            ID = "123",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "-123.45",
            DifferenceFloat = -123.45,
            In = "123.45",
            InFloat = 123.45,
            Name = "Land lord",
            Out = "123.45",
            OutFloat = 123.45,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransferListByAssetAccountResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TransferListByAssetAccountResponse
        {
            ID = "123",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "-123.45",
            DifferenceFloat = -123.45,
            In = "123.45",
            InFloat = 123.45,
            Name = "Land lord",
            Out = "123.45",
            OutFloat = 123.45,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransferListByAssetAccountResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "123";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "5";
        string expectedDifference = "-123.45";
        double expectedDifferenceFloat = -123.45;
        string expectedIn = "123.45";
        double expectedInFloat = 123.45;
        string expectedName = "Land lord";
        string expectedOut = "123.45";
        double expectedOutFloat = 123.45;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedDifference, deserialized.Difference);
        Assert.Equal(expectedDifferenceFloat, deserialized.DifferenceFloat);
        Assert.Equal(expectedIn, deserialized.In);
        Assert.Equal(expectedInFloat, deserialized.InFloat);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOut, deserialized.Out);
        Assert.Equal(expectedOutFloat, deserialized.OutFloat);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TransferListByAssetAccountResponse
        {
            ID = "123",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "-123.45",
            DifferenceFloat = -123.45,
            In = "123.45",
            InFloat = 123.45,
            Name = "Land lord",
            Out = "123.45",
            OutFloat = 123.45,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TransferListByAssetAccountResponse { };

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
        Assert.Null(model.In);
        Assert.False(model.RawData.ContainsKey("in"));
        Assert.Null(model.InFloat);
        Assert.False(model.RawData.ContainsKey("in_float"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Out);
        Assert.False(model.RawData.ContainsKey("out"));
        Assert.Null(model.OutFloat);
        Assert.False(model.RawData.ContainsKey("out_float"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TransferListByAssetAccountResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TransferListByAssetAccountResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CurrencyCode = null,
            CurrencyID = null,
            Difference = null,
            DifferenceFloat = null,
            In = null,
            InFloat = null,
            Name = null,
            Out = null,
            OutFloat = null,
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
        Assert.Null(model.In);
        Assert.False(model.RawData.ContainsKey("in"));
        Assert.Null(model.InFloat);
        Assert.False(model.RawData.ContainsKey("in_float"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Out);
        Assert.False(model.RawData.ContainsKey("out"));
        Assert.Null(model.OutFloat);
        Assert.False(model.RawData.ContainsKey("out_float"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TransferListByAssetAccountResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CurrencyCode = null,
            CurrencyID = null,
            Difference = null,
            DifferenceFloat = null,
            In = null,
            InFloat = null,
            Name = null,
            Out = null,
            OutFloat = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TransferListByAssetAccountResponse
        {
            ID = "123",
            CurrencyCode = "EUR",
            CurrencyID = "5",
            Difference = "-123.45",
            DifferenceFloat = -123.45,
            In = "123.45",
            InFloat = 123.45,
            Name = "Land lord",
            Out = "123.45",
            OutFloat = 123.45,
        };

        TransferListByAssetAccountResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
