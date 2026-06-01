using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.ExchangeRates;

namespace Firefly.Tests.Models.ExchangeRates;

public class CurrencyExchangeRateSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CurrencyExchangeRateSingle
        {
            Data = new()
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
            },
        };

        CurrencyExchangeRateRead expectedData = new()
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

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CurrencyExchangeRateSingle
        {
            Data = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyExchangeRateSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CurrencyExchangeRateSingle
        {
            Data = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyExchangeRateSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CurrencyExchangeRateRead expectedData = new()
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

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CurrencyExchangeRateSingle
        {
            Data = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CurrencyExchangeRateSingle
        {
            Data = new()
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
            },
        };

        CurrencyExchangeRateSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
