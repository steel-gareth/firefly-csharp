using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.ExchangeRates;
using Attachments = EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Tests.Models.ExchangeRates;

public class CurrencyExchangeRateReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CurrencyExchangeRateRead
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                FromCurrencyCode = "EUR",
                FromCurrencyDecimalPlaces = 2,
                FromCurrencyID = "12",
                FromCurrencyName = "Euro",
                FromCurrencySymbol = "$",
                Rate = "1.10340",
                ToCurrencyCode = "EUR",
                ToCurrencyDecimalPlaces = 2,
                ToCurrencyID = "12",
                ToCurrencyName = "EUR",
                ToCurrencySymbol = "$",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "currency_exchange_rates",
        };

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            FromCurrencyCode = "EUR",
            FromCurrencyDecimalPlaces = 2,
            FromCurrencyID = "12",
            FromCurrencyName = "Euro",
            FromCurrencySymbol = "$",
            Rate = "1.10340",
            ToCurrencyCode = "EUR",
            ToCurrencyDecimalPlaces = 2,
            ToCurrencyID = "12",
            ToCurrencyName = "EUR",
            ToCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "currency_exchange_rates";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CurrencyExchangeRateRead
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                FromCurrencyCode = "EUR",
                FromCurrencyDecimalPlaces = 2,
                FromCurrencyID = "12",
                FromCurrencyName = "Euro",
                FromCurrencySymbol = "$",
                Rate = "1.10340",
                ToCurrencyCode = "EUR",
                ToCurrencyDecimalPlaces = 2,
                ToCurrencyID = "12",
                ToCurrencyName = "EUR",
                ToCurrencySymbol = "$",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "currency_exchange_rates",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyExchangeRateRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CurrencyExchangeRateRead
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                FromCurrencyCode = "EUR",
                FromCurrencyDecimalPlaces = 2,
                FromCurrencyID = "12",
                FromCurrencyName = "Euro",
                FromCurrencySymbol = "$",
                Rate = "1.10340",
                ToCurrencyCode = "EUR",
                ToCurrencyDecimalPlaces = 2,
                ToCurrencyID = "12",
                ToCurrencyName = "EUR",
                ToCurrencySymbol = "$",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "currency_exchange_rates",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyExchangeRateRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            FromCurrencyCode = "EUR",
            FromCurrencyDecimalPlaces = 2,
            FromCurrencyID = "12",
            FromCurrencyName = "Euro",
            FromCurrencySymbol = "$",
            Rate = "1.10340",
            ToCurrencyCode = "EUR",
            ToCurrencyDecimalPlaces = 2,
            ToCurrencyID = "12",
            ToCurrencyName = "EUR",
            ToCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "currency_exchange_rates";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CurrencyExchangeRateRead
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                FromCurrencyCode = "EUR",
                FromCurrencyDecimalPlaces = 2,
                FromCurrencyID = "12",
                FromCurrencyName = "Euro",
                FromCurrencySymbol = "$",
                Rate = "1.10340",
                ToCurrencyCode = "EUR",
                ToCurrencyDecimalPlaces = 2,
                ToCurrencyID = "12",
                ToCurrencyName = "EUR",
                ToCurrencySymbol = "$",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "currency_exchange_rates",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CurrencyExchangeRateRead { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Attributes);
        Assert.False(model.RawData.ContainsKey("attributes"));
        Assert.Null(model.Links);
        Assert.False(model.RawData.ContainsKey("links"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CurrencyExchangeRateRead { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CurrencyExchangeRateRead
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Attributes = null,
            Links = null,
            Type = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Attributes);
        Assert.False(model.RawData.ContainsKey("attributes"));
        Assert.Null(model.Links);
        Assert.False(model.RawData.ContainsKey("links"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CurrencyExchangeRateRead
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Attributes = null,
            Links = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CurrencyExchangeRateRead
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                FromCurrencyCode = "EUR",
                FromCurrencyDecimalPlaces = 2,
                FromCurrencyID = "12",
                FromCurrencyName = "Euro",
                FromCurrencySymbol = "$",
                Rate = "1.10340",
                ToCurrencyCode = "EUR",
                ToCurrencyDecimalPlaces = 2,
                ToCurrencyID = "12",
                ToCurrencyName = "EUR",
                ToCurrencySymbol = "$",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "currency_exchange_rates",
        };

        CurrencyExchangeRateRead copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttributesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            FromCurrencyCode = "EUR",
            FromCurrencyDecimalPlaces = 2,
            FromCurrencyID = "12",
            FromCurrencyName = "Euro",
            FromCurrencySymbol = "$",
            Rate = "1.10340",
            ToCurrencyCode = "EUR",
            ToCurrencyDecimalPlaces = 2,
            ToCurrencyID = "12",
            ToCurrencyName = "EUR",
            ToCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedFromCurrencyCode = "EUR";
        int expectedFromCurrencyDecimalPlaces = 2;
        string expectedFromCurrencyID = "12";
        string expectedFromCurrencyName = "Euro";
        string expectedFromCurrencySymbol = "$";
        string expectedRate = "1.10340";
        string expectedToCurrencyCode = "EUR";
        int expectedToCurrencyDecimalPlaces = 2;
        string expectedToCurrencyID = "12";
        string expectedToCurrencyName = "EUR";
        string expectedToCurrencySymbol = "$";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedFromCurrencyCode, model.FromCurrencyCode);
        Assert.Equal(expectedFromCurrencyDecimalPlaces, model.FromCurrencyDecimalPlaces);
        Assert.Equal(expectedFromCurrencyID, model.FromCurrencyID);
        Assert.Equal(expectedFromCurrencyName, model.FromCurrencyName);
        Assert.Equal(expectedFromCurrencySymbol, model.FromCurrencySymbol);
        Assert.Equal(expectedRate, model.Rate);
        Assert.Equal(expectedToCurrencyCode, model.ToCurrencyCode);
        Assert.Equal(expectedToCurrencyDecimalPlaces, model.ToCurrencyDecimalPlaces);
        Assert.Equal(expectedToCurrencyID, model.ToCurrencyID);
        Assert.Equal(expectedToCurrencyName, model.ToCurrencyName);
        Assert.Equal(expectedToCurrencySymbol, model.ToCurrencySymbol);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            FromCurrencyCode = "EUR",
            FromCurrencyDecimalPlaces = 2,
            FromCurrencyID = "12",
            FromCurrencyName = "Euro",
            FromCurrencySymbol = "$",
            Rate = "1.10340",
            ToCurrencyCode = "EUR",
            ToCurrencyDecimalPlaces = 2,
            ToCurrencyID = "12",
            ToCurrencyName = "EUR",
            ToCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            FromCurrencyCode = "EUR",
            FromCurrencyDecimalPlaces = 2,
            FromCurrencyID = "12",
            FromCurrencyName = "Euro",
            FromCurrencySymbol = "$",
            Rate = "1.10340",
            ToCurrencyCode = "EUR",
            ToCurrencyDecimalPlaces = 2,
            ToCurrencyID = "12",
            ToCurrencyName = "EUR",
            ToCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedFromCurrencyCode = "EUR";
        int expectedFromCurrencyDecimalPlaces = 2;
        string expectedFromCurrencyID = "12";
        string expectedFromCurrencyName = "Euro";
        string expectedFromCurrencySymbol = "$";
        string expectedRate = "1.10340";
        string expectedToCurrencyCode = "EUR";
        int expectedToCurrencyDecimalPlaces = 2;
        string expectedToCurrencyID = "12";
        string expectedToCurrencyName = "EUR";
        string expectedToCurrencySymbol = "$";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedFromCurrencyCode, deserialized.FromCurrencyCode);
        Assert.Equal(expectedFromCurrencyDecimalPlaces, deserialized.FromCurrencyDecimalPlaces);
        Assert.Equal(expectedFromCurrencyID, deserialized.FromCurrencyID);
        Assert.Equal(expectedFromCurrencyName, deserialized.FromCurrencyName);
        Assert.Equal(expectedFromCurrencySymbol, deserialized.FromCurrencySymbol);
        Assert.Equal(expectedRate, deserialized.Rate);
        Assert.Equal(expectedToCurrencyCode, deserialized.ToCurrencyCode);
        Assert.Equal(expectedToCurrencyDecimalPlaces, deserialized.ToCurrencyDecimalPlaces);
        Assert.Equal(expectedToCurrencyID, deserialized.ToCurrencyID);
        Assert.Equal(expectedToCurrencyName, deserialized.ToCurrencyName);
        Assert.Equal(expectedToCurrencySymbol, deserialized.ToCurrencySymbol);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            FromCurrencyCode = "EUR",
            FromCurrencyDecimalPlaces = 2,
            FromCurrencyID = "12",
            FromCurrencyName = "Euro",
            FromCurrencySymbol = "$",
            Rate = "1.10340",
            ToCurrencyCode = "EUR",
            ToCurrencyDecimalPlaces = 2,
            ToCurrencyID = "12",
            ToCurrencyName = "EUR",
            ToCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes { };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.FromCurrencyCode);
        Assert.False(model.RawData.ContainsKey("from_currency_code"));
        Assert.Null(model.FromCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("from_currency_decimal_places"));
        Assert.Null(model.FromCurrencyID);
        Assert.False(model.RawData.ContainsKey("from_currency_id"));
        Assert.Null(model.FromCurrencyName);
        Assert.False(model.RawData.ContainsKey("from_currency_name"));
        Assert.Null(model.FromCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("from_currency_symbol"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.ToCurrencyCode);
        Assert.False(model.RawData.ContainsKey("to_currency_code"));
        Assert.Null(model.ToCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("to_currency_decimal_places"));
        Assert.Null(model.ToCurrencyID);
        Assert.False(model.RawData.ContainsKey("to_currency_id"));
        Assert.Null(model.ToCurrencyName);
        Assert.False(model.RawData.ContainsKey("to_currency_name"));
        Assert.Null(model.ToCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("to_currency_symbol"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Date = null,
            FromCurrencyCode = null,
            FromCurrencyDecimalPlaces = null,
            FromCurrencyID = null,
            FromCurrencyName = null,
            FromCurrencySymbol = null,
            Rate = null,
            ToCurrencyCode = null,
            ToCurrencyDecimalPlaces = null,
            ToCurrencyID = null,
            ToCurrencyName = null,
            ToCurrencySymbol = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.FromCurrencyCode);
        Assert.False(model.RawData.ContainsKey("from_currency_code"));
        Assert.Null(model.FromCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("from_currency_decimal_places"));
        Assert.Null(model.FromCurrencyID);
        Assert.False(model.RawData.ContainsKey("from_currency_id"));
        Assert.Null(model.FromCurrencyName);
        Assert.False(model.RawData.ContainsKey("from_currency_name"));
        Assert.Null(model.FromCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("from_currency_symbol"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.ToCurrencyCode);
        Assert.False(model.RawData.ContainsKey("to_currency_code"));
        Assert.Null(model.ToCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("to_currency_decimal_places"));
        Assert.Null(model.ToCurrencyID);
        Assert.False(model.RawData.ContainsKey("to_currency_id"));
        Assert.Null(model.ToCurrencyName);
        Assert.False(model.RawData.ContainsKey("to_currency_name"));
        Assert.Null(model.ToCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("to_currency_symbol"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Date = null,
            FromCurrencyCode = null,
            FromCurrencyDecimalPlaces = null,
            FromCurrencyID = null,
            FromCurrencyName = null,
            FromCurrencySymbol = null,
            Rate = null,
            ToCurrencyCode = null,
            ToCurrencyDecimalPlaces = null,
            ToCurrencyID = null,
            ToCurrencyName = null,
            ToCurrencySymbol = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            FromCurrencyCode = "EUR",
            FromCurrencyDecimalPlaces = 2,
            FromCurrencyID = "12",
            FromCurrencyName = "Euro",
            FromCurrencySymbol = "$",
            Rate = "1.10340",
            ToCurrencyCode = "EUR",
            ToCurrencyDecimalPlaces = 2,
            ToCurrencyID = "12",
            ToCurrencyName = "EUR",
            ToCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
