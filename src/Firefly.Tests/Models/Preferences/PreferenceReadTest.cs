using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Preferences;

namespace Firefly.Tests.Models.Preferences;

public class PreferenceReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceRead
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

        string expectedID = "2";
        Preference expectedAttributes = new()
        {
            Data = true,
            Name = "currencyPreference",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        string expectedType = "preferences";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceRead
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceRead
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Preference expectedAttributes = new()
        {
            Data = true,
            Name = "currencyPreference",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        string expectedType = "preferences";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceRead
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferenceRead
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

        PreferenceRead copied = new(model);

        Assert.Equal(model, copied);
    }
}
