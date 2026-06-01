using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Autocomplete;

namespace Firefly.Tests.Models.Autocomplete;

public class AutocompleteListPiggyBanksWithBalanceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencySymbol = "$",
            NameWithBalance = "New couch ($234.56 / $600)",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
        };

        string expectedID = "2";
        string expectedName = "New couch";
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "12";
        string expectedCurrencySymbol = "$";
        string expectedNameWithBalance = "New couch ($234.56 / $600)";
        string expectedObjectGroupID = "5";
        string expectedObjectGroupTitle = "Example Group";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedNameWithBalance, model.NameWithBalance);
        Assert.Equal(expectedObjectGroupID, model.ObjectGroupID);
        Assert.Equal(expectedObjectGroupTitle, model.ObjectGroupTitle);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencySymbol = "$",
            NameWithBalance = "New couch ($234.56 / $600)",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AutocompleteListPiggyBanksWithBalanceResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencySymbol = "$",
            NameWithBalance = "New couch ($234.56 / $600)",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AutocompleteListPiggyBanksWithBalanceResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedName = "New couch";
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "12";
        string expectedCurrencySymbol = "$";
        string expectedNameWithBalance = "New couch ($234.56 / $600)";
        string expectedObjectGroupID = "5";
        string expectedObjectGroupTitle = "Example Group";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedNameWithBalance, deserialized.NameWithBalance);
        Assert.Equal(expectedObjectGroupID, deserialized.ObjectGroupID);
        Assert.Equal(expectedObjectGroupTitle, deserialized.ObjectGroupTitle);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencySymbol = "$",
            NameWithBalance = "New couch ($234.56 / $600)",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
        };

        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.NameWithBalance);
        Assert.False(model.RawData.ContainsKey("name_with_balance"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",

            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencySymbol = null,
            NameWithBalance = null,
        };

        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.NameWithBalance);
        Assert.False(model.RawData.ContainsKey("name_with_balance"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",

            // Null should be interpreted as omitted for these properties
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencySymbol = null,
            NameWithBalance = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencySymbol = "$",
            NameWithBalance = "New couch ($234.56 / $600)",
        };

        Assert.Null(model.ObjectGroupID);
        Assert.False(model.RawData.ContainsKey("object_group_id"));
        Assert.Null(model.ObjectGroupTitle);
        Assert.False(model.RawData.ContainsKey("object_group_title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencySymbol = "$",
            NameWithBalance = "New couch ($234.56 / $600)",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencySymbol = "$",
            NameWithBalance = "New couch ($234.56 / $600)",

            ObjectGroupID = null,
            ObjectGroupTitle = null,
        };

        Assert.Null(model.ObjectGroupID);
        Assert.True(model.RawData.ContainsKey("object_group_id"));
        Assert.Null(model.ObjectGroupTitle);
        Assert.True(model.RawData.ContainsKey("object_group_title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencySymbol = "$",
            NameWithBalance = "New couch ($234.56 / $600)",

            ObjectGroupID = null,
            ObjectGroupTitle = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListPiggyBanksWithBalanceResponse
        {
            ID = "2",
            Name = "New couch",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencySymbol = "$",
            NameWithBalance = "New couch ($234.56 / $600)",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
        };

        AutocompleteListPiggyBanksWithBalanceResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
