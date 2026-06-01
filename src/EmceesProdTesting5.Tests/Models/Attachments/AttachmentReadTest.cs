using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Tests.Models.Attachments;

public class AttachmentReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttachmentRead
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

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "attachments";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttachmentRead
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachmentRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttachmentRead
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachmentRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "attachments";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttachmentRead
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttachmentRead
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

        AttachmentRead copied = new(model);

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
        };

        string expectedAttachableID = "134";
        ApiEnum<string, AttachableType> expectedAttachableType = AttachableType.Bill;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDownloadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download";
        string expectedFilename = "file.pdf";
        string expectedHash = "0c3f95f34370baa88f9fd9a671fea305";
        string expectedMime = "application/pdf";
        string expectedNotes = "Some notes";
        int expectedSize = 48211;
        string expectedTitle = "Some PDF file";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedUploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download";

        Assert.Equal(expectedAttachableID, model.AttachableID);
        Assert.Equal(expectedAttachableType, model.AttachableType);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDownloadUrl, model.DownloadUrl);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedHash, model.Hash);
        Assert.Equal(expectedMime, model.Mime);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedSize, model.Size);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUploadUrl, model.UploadUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAttachableID = "134";
        ApiEnum<string, AttachableType> expectedAttachableType = AttachableType.Bill;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedDownloadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download";
        string expectedFilename = "file.pdf";
        string expectedHash = "0c3f95f34370baa88f9fd9a671fea305";
        string expectedMime = "application/pdf";
        string expectedNotes = "Some notes";
        int expectedSize = 48211;
        string expectedTitle = "Some PDF file";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedUploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download";

        Assert.Equal(expectedAttachableID, deserialized.AttachableID);
        Assert.Equal(expectedAttachableType, deserialized.AttachableType);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDownloadUrl, deserialized.DownloadUrl);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedHash, deserialized.Hash);
        Assert.Equal(expectedMime, deserialized.Mime);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedSize, deserialized.Size);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUploadUrl, deserialized.UploadUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes { Notes = "Some notes", Title = "Some PDF file" };

        Assert.Null(model.AttachableID);
        Assert.False(model.RawData.ContainsKey("attachable_id"));
        Assert.Null(model.AttachableType);
        Assert.False(model.RawData.ContainsKey("attachable_type"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DownloadUrl);
        Assert.False(model.RawData.ContainsKey("download_url"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.Hash);
        Assert.False(model.RawData.ContainsKey("hash"));
        Assert.Null(model.Mime);
        Assert.False(model.RawData.ContainsKey("mime"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.UploadUrl);
        Assert.False(model.RawData.ContainsKey("upload_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes { Notes = "Some notes", Title = "Some PDF file" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Notes = "Some notes",
            Title = "Some PDF file",

            // Null should be interpreted as omitted for these properties
            AttachableID = null,
            AttachableType = null,
            CreatedAt = null,
            DownloadUrl = null,
            Filename = null,
            Hash = null,
            Mime = null,
            Size = null,
            UpdatedAt = null,
            UploadUrl = null,
        };

        Assert.Null(model.AttachableID);
        Assert.False(model.RawData.ContainsKey("attachable_id"));
        Assert.Null(model.AttachableType);
        Assert.False(model.RawData.ContainsKey("attachable_type"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DownloadUrl);
        Assert.False(model.RawData.ContainsKey("download_url"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.Hash);
        Assert.False(model.RawData.ContainsKey("hash"));
        Assert.Null(model.Mime);
        Assert.False(model.RawData.ContainsKey("mime"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.UploadUrl);
        Assert.False(model.RawData.ContainsKey("upload_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Notes = "Some notes",
            Title = "Some PDF file",

            // Null should be interpreted as omitted for these properties
            AttachableID = null,
            AttachableType = null,
            CreatedAt = null,
            DownloadUrl = null,
            Filename = null,
            Hash = null,
            Mime = null,
            Size = null,
            UpdatedAt = null,
            UploadUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DownloadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
            Filename = "file.pdf",
            Hash = "0c3f95f34370baa88f9fd9a671fea305",
            Mime = "application/pdf",
            Size = 48211,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
        };

        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DownloadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
            Filename = "file.pdf",
            Hash = "0c3f95f34370baa88f9fd9a671fea305",
            Mime = "application/pdf",
            Size = 48211,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DownloadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
            Filename = "file.pdf",
            Hash = "0c3f95f34370baa88f9fd9a671fea305",
            Mime = "application/pdf",
            Size = 48211,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",

            Notes = null,
            Title = null,
        };

        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            AttachableID = "134",
            AttachableType = AttachableType.Bill,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            DownloadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",
            Filename = "file.pdf",
            Hash = "0c3f95f34370baa88f9fd9a671fea305",
            Mime = "application/pdf",
            Size = 48211,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UploadUrl = "https://demo.firefly-iii.org/api/v1/attachments/191/download",

            Notes = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
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
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
