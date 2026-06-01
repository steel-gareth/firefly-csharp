using System.Text.Json;
using Firefly.Core;
using Firefly.Models.LinkTypes;

namespace Firefly.Tests.Models.LinkTypes;

public class LinkTypeSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LinkTypeSingle
        {
            Data = new()
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
            },
        };

        LinkTypeRead expectedData = new()
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

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LinkTypeSingle
        {
            Data = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LinkTypeSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LinkTypeSingle
        {
            Data = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LinkTypeSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        LinkTypeRead expectedData = new()
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

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LinkTypeSingle
        {
            Data = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LinkTypeSingle
        {
            Data = new()
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
            },
        };

        LinkTypeSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
