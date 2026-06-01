using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Tags;

namespace Firefly.Tests.Models.Tags;

public class TagSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TagSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Tag = "expensive",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Date = "2026-04-01",
                    Description = "Tag for expensive stuff",
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    ZoomLevel = 6,
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "tags",
            },
        };

        TagRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Tag = "expensive",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Date = "2026-04-01",
                Description = "Tag for expensive stuff",
                Latitude = 51.983333,
                Longitude = 5.916667,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                ZoomLevel = 6,
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "tags",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TagSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Tag = "expensive",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Date = "2026-04-01",
                    Description = "Tag for expensive stuff",
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    ZoomLevel = 6,
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "tags",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TagSingle>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TagSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Tag = "expensive",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Date = "2026-04-01",
                    Description = "Tag for expensive stuff",
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    ZoomLevel = 6,
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "tags",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TagSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TagRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Tag = "expensive",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Date = "2026-04-01",
                Description = "Tag for expensive stuff",
                Latitude = 51.983333,
                Longitude = 5.916667,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                ZoomLevel = 6,
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "tags",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TagSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Tag = "expensive",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Date = "2026-04-01",
                    Description = "Tag for expensive stuff",
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    ZoomLevel = 6,
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "tags",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TagSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Tag = "expensive",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Date = "2026-04-01",
                    Description = "Tag for expensive stuff",
                    Latitude = 51.983333,
                    Longitude = 5.916667,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    ZoomLevel = 6,
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "tags",
            },
        };

        TagSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
