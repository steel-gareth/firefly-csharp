using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.TransactionLinks;

namespace EmceesProdTesting5.Tests.Models.TransactionLinks;

public class TransactionLinkSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TransactionLinkSingle
        {
            Data = new()
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
            },
        };

        TransactionLinkRead expectedData = new()
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

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TransactionLinkSingle
        {
            Data = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionLinkSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TransactionLinkSingle
        {
            Data = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TransactionLinkSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TransactionLinkRead expectedData = new()
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

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TransactionLinkSingle
        {
            Data = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TransactionLinkSingle
        {
            Data = new()
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
            },
        };

        TransactionLinkSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
