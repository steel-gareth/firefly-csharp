using System;
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.ObjectGroups;

namespace Firefly.Tests.Models.ObjectGroups;

public class ObjectGroupListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectGroupListResponse
        {
            Data =
            [
                new()
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
            ],
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        List<ObjectGroupRead> expectedData =
        [
            new()
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
        ];
        Meta expectedMeta = new()
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedMeta, model.Meta);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectGroupListResponse
        {
            Data =
            [
                new()
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
            ],
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGroupListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectGroupListResponse
        {
            Data =
            [
                new()
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
            ],
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectGroupListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ObjectGroupRead> expectedData =
        [
            new()
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
        ];
        Meta expectedMeta = new()
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedMeta, deserialized.Meta);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectGroupListResponse
        {
            Data =
            [
                new()
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
            ],
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectGroupListResponse
        {
            Data =
            [
                new()
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
            ],
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        ObjectGroupListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
