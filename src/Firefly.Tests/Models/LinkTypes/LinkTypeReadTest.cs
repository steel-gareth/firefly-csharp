using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Attachments;
using Firefly.Models.LinkTypes;

namespace Firefly.Tests.Models.LinkTypes;

public class LinkTypeReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LinkTypeRead
        {
            ID = "2",
            Attributes = new()
            {
                Inward = "is (partially) paid for by",
                Name = "Paid",
                Outward = "(partially) pays for",
                Editable = false,
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "link_types",
        };

        string expectedID = "2";
        LinkType expectedAttributes = new()
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
            Editable = false,
        };
        ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "link_types";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LinkTypeRead
        {
            ID = "2",
            Attributes = new()
            {
                Inward = "is (partially) paid for by",
                Name = "Paid",
                Outward = "(partially) pays for",
                Editable = false,
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "link_types",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LinkTypeRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LinkTypeRead
        {
            ID = "2",
            Attributes = new()
            {
                Inward = "is (partially) paid for by",
                Name = "Paid",
                Outward = "(partially) pays for",
                Editable = false,
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "link_types",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LinkTypeRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        LinkType expectedAttributes = new()
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
            Editable = false,
        };
        ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "link_types";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LinkTypeRead
        {
            ID = "2",
            Attributes = new()
            {
                Inward = "is (partially) paid for by",
                Name = "Paid",
                Outward = "(partially) pays for",
                Editable = false,
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "link_types",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LinkTypeRead
        {
            ID = "2",
            Attributes = new()
            {
                Inward = "is (partially) paid for by",
                Name = "Paid",
                Outward = "(partially) pays for",
                Editable = false,
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "link_types",
        };

        LinkTypeRead copied = new(model);

        Assert.Equal(model, copied);
    }
}
