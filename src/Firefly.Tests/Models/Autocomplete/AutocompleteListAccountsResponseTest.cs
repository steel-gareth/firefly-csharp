using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Autocomplete;

namespace Firefly.Tests.Models.Autocomplete;

public class AutocompleteListAccountsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListAccountsResponse
        {
            ID = "2",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Name = "Checking Account",
            NameWithBalance = "Checking Account ($123.45)",
            Type = "Asset account",
            AccountCurrencyCode = "USD",
            AccountCurrencyDecimalPlaces = 2,
            AccountCurrencyID = "2",
            AccountCurrencyName = "US Dollar",
            AccountCurrencySymbol = "$",
            Active = true,
        };

        string expectedID = "2";
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "12";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedName = "Checking Account";
        string expectedNameWithBalance = "Checking Account ($123.45)";
        string expectedType = "Asset account";
        string expectedAccountCurrencyCode = "USD";
        int expectedAccountCurrencyDecimalPlaces = 2;
        string expectedAccountCurrencyID = "2";
        string expectedAccountCurrencyName = "US Dollar";
        string expectedAccountCurrencySymbol = "$";
        bool expectedActive = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNameWithBalance, model.NameWithBalance);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAccountCurrencyCode, model.AccountCurrencyCode);
        Assert.Equal(expectedAccountCurrencyDecimalPlaces, model.AccountCurrencyDecimalPlaces);
        Assert.Equal(expectedAccountCurrencyID, model.AccountCurrencyID);
        Assert.Equal(expectedAccountCurrencyName, model.AccountCurrencyName);
        Assert.Equal(expectedAccountCurrencySymbol, model.AccountCurrencySymbol);
        Assert.Equal(expectedActive, model.Active);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListAccountsResponse
        {
            ID = "2",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Name = "Checking Account",
            NameWithBalance = "Checking Account ($123.45)",
            Type = "Asset account",
            AccountCurrencyCode = "USD",
            AccountCurrencyDecimalPlaces = 2,
            AccountCurrencyID = "2",
            AccountCurrencyName = "US Dollar",
            AccountCurrencySymbol = "$",
            Active = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListAccountsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListAccountsResponse
        {
            ID = "2",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Name = "Checking Account",
            NameWithBalance = "Checking Account ($123.45)",
            Type = "Asset account",
            AccountCurrencyCode = "USD",
            AccountCurrencyDecimalPlaces = 2,
            AccountCurrencyID = "2",
            AccountCurrencyName = "US Dollar",
            AccountCurrencySymbol = "$",
            Active = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListAccountsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "12";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedName = "Checking Account";
        string expectedNameWithBalance = "Checking Account ($123.45)";
        string expectedType = "Asset account";
        string expectedAccountCurrencyCode = "USD";
        int expectedAccountCurrencyDecimalPlaces = 2;
        string expectedAccountCurrencyID = "2";
        string expectedAccountCurrencyName = "US Dollar";
        string expectedAccountCurrencySymbol = "$";
        bool expectedActive = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNameWithBalance, deserialized.NameWithBalance);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAccountCurrencyCode, deserialized.AccountCurrencyCode);
        Assert.Equal(
            expectedAccountCurrencyDecimalPlaces,
            deserialized.AccountCurrencyDecimalPlaces
        );
        Assert.Equal(expectedAccountCurrencyID, deserialized.AccountCurrencyID);
        Assert.Equal(expectedAccountCurrencyName, deserialized.AccountCurrencyName);
        Assert.Equal(expectedAccountCurrencySymbol, deserialized.AccountCurrencySymbol);
        Assert.Equal(expectedActive, deserialized.Active);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListAccountsResponse
        {
            ID = "2",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Name = "Checking Account",
            NameWithBalance = "Checking Account ($123.45)",
            Type = "Asset account",
            AccountCurrencyCode = "USD",
            AccountCurrencyDecimalPlaces = 2,
            AccountCurrencyID = "2",
            AccountCurrencyName = "US Dollar",
            AccountCurrencySymbol = "$",
            Active = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutocompleteListAccountsResponse
        {
            ID = "2",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Name = "Checking Account",
            NameWithBalance = "Checking Account ($123.45)",
            Type = "Asset account",
        };

        Assert.Null(model.AccountCurrencyCode);
        Assert.False(model.RawData.ContainsKey("account_currency_code"));
        Assert.Null(model.AccountCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("account_currency_decimal_places"));
        Assert.Null(model.AccountCurrencyID);
        Assert.False(model.RawData.ContainsKey("account_currency_id"));
        Assert.Null(model.AccountCurrencyName);
        Assert.False(model.RawData.ContainsKey("account_currency_name"));
        Assert.Null(model.AccountCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("account_currency_symbol"));
        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutocompleteListAccountsResponse
        {
            ID = "2",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Name = "Checking Account",
            NameWithBalance = "Checking Account ($123.45)",
            Type = "Asset account",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AutocompleteListAccountsResponse
        {
            ID = "2",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Name = "Checking Account",
            NameWithBalance = "Checking Account ($123.45)",
            Type = "Asset account",

            // Null should be interpreted as omitted for these properties
            AccountCurrencyCode = null,
            AccountCurrencyDecimalPlaces = null,
            AccountCurrencyID = null,
            AccountCurrencyName = null,
            AccountCurrencySymbol = null,
            Active = null,
        };

        Assert.Null(model.AccountCurrencyCode);
        Assert.False(model.RawData.ContainsKey("account_currency_code"));
        Assert.Null(model.AccountCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("account_currency_decimal_places"));
        Assert.Null(model.AccountCurrencyID);
        Assert.False(model.RawData.ContainsKey("account_currency_id"));
        Assert.Null(model.AccountCurrencyName);
        Assert.False(model.RawData.ContainsKey("account_currency_name"));
        Assert.Null(model.AccountCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("account_currency_symbol"));
        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutocompleteListAccountsResponse
        {
            ID = "2",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Name = "Checking Account",
            NameWithBalance = "Checking Account ($123.45)",
            Type = "Asset account",

            // Null should be interpreted as omitted for these properties
            AccountCurrencyCode = null,
            AccountCurrencyDecimalPlaces = null,
            AccountCurrencyID = null,
            AccountCurrencyName = null,
            AccountCurrencySymbol = null,
            Active = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListAccountsResponse
        {
            ID = "2",
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "12",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            Name = "Checking Account",
            NameWithBalance = "Checking Account ($123.45)",
            Type = "Asset account",
            AccountCurrencyCode = "USD",
            AccountCurrencyDecimalPlaces = 2,
            AccountCurrencyID = "2",
            AccountCurrencyName = "US Dollar",
            AccountCurrencySymbol = "$",
            Active = true,
        };

        AutocompleteListAccountsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
