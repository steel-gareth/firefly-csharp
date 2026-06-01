using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Tests.Models.Attachments;

public class AttachmentSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttachmentSingle
        {
            Data = new()
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
        };

        AttachmentRead expectedData = new()
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
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttachmentSingle
        {
            Data = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachmentSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttachmentSingle
        {
            Data = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachmentSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AttachmentRead expectedData = new()
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
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttachmentSingle
        {
            Data = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttachmentSingle
        {
            Data = new()
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
        };

        AttachmentSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
