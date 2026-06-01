using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.TransactionLinks;
using Attachments = Firefly.Models.Attachments;

namespace Firefly.Tests.Models.TransactionLinks;

public class TransactionLinkReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TransactionLinkRead
        {
            ID = "2",
            Attributes = new()
            {
                InwardID = "131",
                LinkTypeID = "5",
                OutwardID = "131",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                LinkTypeName = "Is paid by",
                Notes = "Some example notes",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "transactionLinks",
        };

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "transactionLinks";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TransactionLinkRead
        {
            ID = "2",
            Attributes = new()
            {
                InwardID = "131",
                LinkTypeID = "5",
                OutwardID = "131",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                LinkTypeName = "Is paid by",
                Notes = "Some example notes",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "transactionLinks",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionLinkRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TransactionLinkRead
        {
            ID = "2",
            Attributes = new()
            {
                InwardID = "131",
                LinkTypeID = "5",
                OutwardID = "131",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                LinkTypeName = "Is paid by",
                Notes = "Some example notes",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "transactionLinks",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionLinkRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "transactionLinks";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TransactionLinkRead
        {
            ID = "2",
            Attributes = new()
            {
                InwardID = "131",
                LinkTypeID = "5",
                OutwardID = "131",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                LinkTypeName = "Is paid by",
                Notes = "Some example notes",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "transactionLinks",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TransactionLinkRead
        {
            ID = "2",
            Attributes = new()
            {
                InwardID = "131",
                LinkTypeID = "5",
                OutwardID = "131",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                LinkTypeName = "Is paid by",
                Notes = "Some example notes",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "transactionLinks",
        };

        TransactionLinkRead copied = new(model);

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
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string expectedInwardID = "131";
        string expectedLinkTypeID = "5";
        string expectedOutwardID = "131";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedLinkTypeName = "Is paid by";
        string expectedNotes = "Some example notes";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedInwardID, model.InwardID);
        Assert.Equal(expectedLinkTypeID, model.LinkTypeID);
        Assert.Equal(expectedOutwardID, model.OutwardID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedLinkTypeName, model.LinkTypeName);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
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
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInwardID = "131";
        string expectedLinkTypeID = "5";
        string expectedOutwardID = "131";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedLinkTypeName = "Is paid by";
        string expectedNotes = "Some example notes";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedInwardID, deserialized.InwardID);
        Assert.Equal(expectedLinkTypeID, deserialized.LinkTypeID);
        Assert.Equal(expectedOutwardID, deserialized.OutwardID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedLinkTypeName, deserialized.LinkTypeName);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            Notes = "Some example notes",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.LinkTypeName);
        Assert.False(model.RawData.ContainsKey("link_type_name"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            Notes = "Some example notes",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            Notes = "Some example notes",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            LinkTypeName = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.LinkTypeName);
        Assert.False(model.RawData.ContainsKey("link_type_name"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            Notes = "Some example notes",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            LinkTypeName = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            Notes = null,
        };

        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            Notes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            InwardID = "131",
            LinkTypeID = "5",
            OutwardID = "131",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            LinkTypeName = "Is paid by",
            Notes = "Some example notes",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
