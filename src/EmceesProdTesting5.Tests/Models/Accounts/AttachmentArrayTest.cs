using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Tests.Models.Accounts;

public class AttachmentArrayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttachmentArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        AttachableID = "134",
                        AttachableType = AttachableType.Bill,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        DownloadUrl =
                            "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                        Filename = "file.pdf",
                        Hash = "0c3f95f34370baa88f9fd9a671fea305",
                        Mime = "application/pdf",
                        Notes = "Some notes",
                        Size = 48211,
                        Title = "Some PDF file",
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "attachments",
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

        List<AttachmentRead> expectedData =
        [
            new()
            {
                ID = "2",
                Attributes = new()
                {
                    AttachableID = "134",
                    AttachableType = AttachableType.Bill,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    DownloadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                    Filename = "file.pdf",
                    Hash = "0c3f95f34370baa88f9fd9a671fea305",
                    Mime = "application/pdf",
                    Notes = "Some notes",
                    Size = 48211,
                    Title = "Some PDF file",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "attachments",
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
        var model = new AttachmentArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        AttachableID = "134",
                        AttachableType = AttachableType.Bill,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        DownloadUrl =
                            "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                        Filename = "file.pdf",
                        Hash = "0c3f95f34370baa88f9fd9a671fea305",
                        Mime = "application/pdf",
                        Notes = "Some notes",
                        Size = 48211,
                        Title = "Some PDF file",
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "attachments",
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
        var deserialized = JsonSerializer.Deserialize<AttachmentArray>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttachmentArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        AttachableID = "134",
                        AttachableType = AttachableType.Bill,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        DownloadUrl =
                            "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                        Filename = "file.pdf",
                        Hash = "0c3f95f34370baa88f9fd9a671fea305",
                        Mime = "application/pdf",
                        Notes = "Some notes",
                        Size = 48211,
                        Title = "Some PDF file",
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "attachments",
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
        var deserialized = JsonSerializer.Deserialize<AttachmentArray>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AttachmentRead> expectedData =
        [
            new()
            {
                ID = "2",
                Attributes = new()
                {
                    AttachableID = "134",
                    AttachableType = AttachableType.Bill,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    DownloadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                    Filename = "file.pdf",
                    Hash = "0c3f95f34370baa88f9fd9a671fea305",
                    Mime = "application/pdf",
                    Notes = "Some notes",
                    Size = 48211,
                    Title = "Some PDF file",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "attachments",
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
        var model = new AttachmentArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        AttachableID = "134",
                        AttachableType = AttachableType.Bill,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        DownloadUrl =
                            "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                        Filename = "file.pdf",
                        Hash = "0c3f95f34370baa88f9fd9a671fea305",
                        Mime = "application/pdf",
                        Notes = "Some notes",
                        Size = 48211,
                        Title = "Some PDF file",
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "attachments",
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
        var model = new AttachmentArray
        {
            Data =
            [
                new()
                {
                    ID = "2",
                    Attributes = new()
                    {
                        AttachableID = "134",
                        AttachableType = AttachableType.Bill,
                        CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        DownloadUrl =
                            "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                        Filename = "file.pdf",
                        Hash = "0c3f95f34370baa88f9fd9a671fea305",
                        Mime = "application/pdf",
                        Notes = "Some notes",
                        Size = 48211,
                        Title = "Some PDF file",
                        UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                    },
                    Links = new()
                    {
                        O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                        Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                    },
                    Type = "attachments",
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

        AttachmentArray copied = new(model);

        Assert.Equal(model, copied);
    }
}
