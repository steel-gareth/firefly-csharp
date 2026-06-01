using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Autocomplete;

namespace EmceesProdTesting5.Tests.Models.Autocomplete;

public class AutocompleteListCurrenciesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListCurrenciesResponse
        {
            ID = "2",
            Code = "EUR",
            DecimalPlaces = 2,
            Name = "Currency name",
            Symbol = "$",
        };

        string expectedID = "2";
        string expectedCode = "EUR";
        int expectedDecimalPlaces = 2;
        string expectedName = "Currency name";
        string expectedSymbol = "$";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedDecimalPlaces, model.DecimalPlaces);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSymbol, model.Symbol);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListCurrenciesResponse
        {
            ID = "2",
            Code = "EUR",
            DecimalPlaces = 2,
            Name = "Currency name",
            Symbol = "$",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListCurrenciesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListCurrenciesResponse
        {
            ID = "2",
            Code = "EUR",
            DecimalPlaces = 2,
            Name = "Currency name",
            Symbol = "$",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListCurrenciesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedCode = "EUR";
        int expectedDecimalPlaces = 2;
        string expectedName = "Currency name";
        string expectedSymbol = "$";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedDecimalPlaces, deserialized.DecimalPlaces);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSymbol, deserialized.Symbol);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListCurrenciesResponse
        {
            ID = "2",
            Code = "EUR",
            DecimalPlaces = 2,
            Name = "Currency name",
            Symbol = "$",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListCurrenciesResponse
        {
            ID = "2",
            Code = "EUR",
            DecimalPlaces = 2,
            Name = "Currency name",
            Symbol = "$",
        };

        AutocompleteListCurrenciesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
