using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Preferences;

namespace EmceesProdTesting5.Tests.Models.Preferences;

public class PreferenceSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Data = true,
                    Name = "currencyPreference",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "preferences",
            },
        };

        PreferenceRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Data = true,
                Name = "currencyPreference",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "preferences",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Data = true,
                    Name = "currencyPreference",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "preferences",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Data = true,
                    Name = "currencyPreference",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "preferences",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PreferenceRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Data = true,
                Name = "currencyPreference",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "preferences",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Data = true,
                    Name = "currencyPreference",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "preferences",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferenceSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Data = true,
                    Name = "currencyPreference",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "preferences",
            },
        };

        PreferenceSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
