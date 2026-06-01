using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Tags;

namespace EmceesProdTesting5.Tests.Models.Tags;

public class TagListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TagListResponse
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
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

        List<TagRead> expectedData =
        [
            new()
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
        ];
        PageLink expectedLinks = new()
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };
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
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedMeta, model.Meta);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TagListResponse
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
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
        var deserialized = JsonSerializer.Deserialize<TagListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TagListResponse
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
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
        var deserialized = JsonSerializer.Deserialize<TagListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TagRead> expectedData =
        [
            new()
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
        ];
        PageLink expectedLinks = new()
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };
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
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedMeta, deserialized.Meta);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TagListResponse
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
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
        var model = new TagListResponse
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
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

        TagListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
