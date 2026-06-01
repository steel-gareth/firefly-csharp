using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Tags;
using Attachments = Firefly.Models.Attachments;

namespace Firefly.Tests.Models.Tags;

public class TagReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TagRead
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

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            ZoomLevel = 6,
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "tags";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TagRead
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TagRead>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TagRead
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TagRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            ZoomLevel = 6,
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "tags";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TagRead
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TagRead
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

        TagRead copied = new(model);

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
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            ZoomLevel = 6,
        };

        string expectedTag = "expensive";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDate = "2026-04-01";
        string expectedDescription = "Tag for expensive stuff";
        double expectedLatitude = 51.983333;
        double expectedLongitude = 5.916667;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        int expectedZoomLevel = 6;

        Assert.Equal(expectedTag, model.Tag);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLongitude, model.Longitude);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedZoomLevel, model.ZoomLevel);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            ZoomLevel = 6,
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
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            ZoomLevel = 6,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTag = "expensive";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDate = "2026-04-01";
        string expectedDescription = "Tag for expensive stuff";
        double expectedLatitude = 51.983333;
        double expectedLongitude = 5.916667;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        int expectedZoomLevel = 6;

        Assert.Equal(expectedTag, deserialized.Tag);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedZoomLevel, deserialized.ZoomLevel);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            ZoomLevel = 6,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Tag = "expensive",
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            ZoomLevel = 6,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Tag = "expensive",
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            ZoomLevel = 6,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Tag = "expensive",
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            ZoomLevel = 6,

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
        var model = new Attributes
        {
            Tag = "expensive",
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            ZoomLevel = 6,

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.ZoomLevel);
        Assert.False(model.RawData.ContainsKey("zoom_level"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            Date = null,
            Description = null,
            Latitude = null,
            Longitude = null,
            ZoomLevel = null,
        };

        Assert.Null(model.Date);
        Assert.True(model.RawData.ContainsKey("date"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Latitude);
        Assert.True(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.Longitude);
        Assert.True(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.ZoomLevel);
        Assert.True(model.RawData.ContainsKey("zoom_level"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            Date = null,
            Description = null,
            Latitude = null,
            Longitude = null,
            ZoomLevel = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            Tag = "expensive",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Date = "2026-04-01",
            Description = "Tag for expensive stuff",
            Latitude = 51.983333,
            Longitude = 5.916667,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            ZoomLevel = 6,
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
