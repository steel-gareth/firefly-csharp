using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Currencies;

namespace Firefly.Tests.Models.Currencies;

public class CurrencyReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CurrencyRead
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

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DecimalPlaces = 2,
            Enabled = true,
            Primary = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        string expectedType = "currencies";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CurrencyRead
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CurrencyRead
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CurrencyRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DecimalPlaces = 2,
            Enabled = true,
            Primary = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        string expectedType = "currencies";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CurrencyRead
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CurrencyRead
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

        CurrencyRead copied = new(model);

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
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DecimalPlaces = 2,
            Enabled = true,
            Primary = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string expectedCode = "AMS";
        string expectedName = "Ankh-Morpork dollar";
        string expectedSymbol = "AM$";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        int expectedDecimalPlaces = 2;
        bool expectedEnabled = true;
        bool expectedPrimary = false;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSymbol, model.Symbol);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDecimalPlaces, model.DecimalPlaces);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedPrimary, model.Primary);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DecimalPlaces = 2,
            Enabled = true,
            Primary = false,
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
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DecimalPlaces = 2,
            Enabled = true,
            Primary = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "AMS";
        string expectedName = "Ankh-Morpork dollar";
        string expectedSymbol = "AM$";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        int expectedDecimalPlaces = 2;
        bool expectedEnabled = true;
        bool expectedPrimary = false;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSymbol, deserialized.Symbol);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDecimalPlaces, deserialized.DecimalPlaces);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedPrimary, deserialized.Primary);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DecimalPlaces = 2,
            Enabled = true,
            Primary = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DecimalPlaces);
        Assert.False(model.RawData.ContainsKey("decimal_places"));
        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.Primary);
        Assert.False(model.RawData.ContainsKey("primary"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            DecimalPlaces = null,
            Enabled = null,
            Primary = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DecimalPlaces);
        Assert.False(model.RawData.ContainsKey("decimal_places"));
        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.Primary);
        Assert.False(model.RawData.ContainsKey("primary"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            DecimalPlaces = null,
            Enabled = null,
            Primary = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            Code = "AMS",
            Name = "Ankh-Morpork dollar",
            Symbol = "AM$",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DecimalPlaces = 2,
            Enabled = true,
            Primary = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
