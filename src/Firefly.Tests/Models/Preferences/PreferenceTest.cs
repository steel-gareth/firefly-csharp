using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Configuration;
using Firefly.Models.Preferences;

namespace Firefly.Tests.Models.Preferences;

public class PreferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Preference
        {
            Data = true,
            Name = "currencyPreference",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        PolymorphicProperty expectedData = true;
        string expectedName = "currencyPreference";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Preference
        {
            Data = true,
            Name = "currencyPreference",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Preference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Preference
        {
            Data = true,
            Name = "currencyPreference",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Preference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PolymorphicProperty expectedData = true;
        string expectedName = "currencyPreference";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Preference
        {
            Data = true,
            Name = "currencyPreference",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Preference { Data = true, Name = "currencyPreference" };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Preference { Data = true, Name = "currencyPreference" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Preference
        {
            Data = true,
            Name = "currencyPreference",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Preference
        {
            Data = true,
            Name = "currencyPreference",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Preference
        {
            Data = true,
            Name = "currencyPreference",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Preference copied = new(model);

        Assert.Equal(model, copied);
    }
}
