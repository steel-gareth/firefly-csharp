using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.ObjectGroups;

namespace EmceesProdTesting5.Tests.Models.ObjectGroups;

public class ObjectGroupSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Order = 1,
                    Title = "My object group",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "object_groups",
            },
        };

        ObjectGroupRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Order = 1,
                Title = "My object group",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "object_groups",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Order = 1,
                    Title = "My object group",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "object_groups",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGroupSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Order = 1,
                    Title = "My object group",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "object_groups",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGroupSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ObjectGroupRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Order = 1,
                Title = "My object group",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "object_groups",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Order = 1,
                    Title = "My object group",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "object_groups",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Order = 1,
                    Title = "My object group",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "object_groups",
            },
        };

        ObjectGroupSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
