using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Currencies;

namespace EmceesProdTesting5.Tests.Models.Currencies;

public class CurrencySingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CurrencySingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Code = "AMS",
                    Name = "Ankh-Morpork dollar",
                    Symbol = "AM$",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    DecimalPlaces = 2,
                    Enabled = true,
                    Primary = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "currencies",
            },
        };

        CurrencyRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Code = "AMS",
                Name = "Ankh-Morpork dollar",
                Symbol = "AM$",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                DecimalPlaces = 2,
                Enabled = true,
                Primary = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "currencies",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CurrencySingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Code = "AMS",
                    Name = "Ankh-Morpork dollar",
                    Symbol = "AM$",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    DecimalPlaces = 2,
                    Enabled = true,
                    Primary = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "currencies",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencySingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CurrencySingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Code = "AMS",
                    Name = "Ankh-Morpork dollar",
                    Symbol = "AM$",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    DecimalPlaces = 2,
                    Enabled = true,
                    Primary = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "currencies",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencySingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CurrencyRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Code = "AMS",
                Name = "Ankh-Morpork dollar",
                Symbol = "AM$",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                DecimalPlaces = 2,
                Enabled = true,
                Primary = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "currencies",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CurrencySingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Code = "AMS",
                    Name = "Ankh-Morpork dollar",
                    Symbol = "AM$",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    DecimalPlaces = 2,
                    Enabled = true,
                    Primary = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "currencies",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CurrencySingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Code = "AMS",
                    Name = "Ankh-Morpork dollar",
                    Symbol = "AM$",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    DecimalPlaces = 2,
                    Enabled = true,
                    Primary = false,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "currencies",
            },
        };

        CurrencySingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
