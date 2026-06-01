using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.LinkTypes;

namespace EmceesProdTesting5.Tests.Models.LinkTypes;

public class LinkTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LinkType
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
            Editable = false,
        };

        string expectedInward = "is (partially) paid for by";
        string expectedName = "Paid";
        string expectedOutward = "(partially) pays for";
        bool expectedEditable = false;

        Assert.Equal(expectedInward, model.Inward);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOutward, model.Outward);
        Assert.Equal(expectedEditable, model.Editable);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LinkType
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
            Editable = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LinkType>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LinkType
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
            Editable = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LinkType>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInward = "is (partially) paid for by";
        string expectedName = "Paid";
        string expectedOutward = "(partially) pays for";
        bool expectedEditable = false;

        Assert.Equal(expectedInward, deserialized.Inward);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOutward, deserialized.Outward);
        Assert.Equal(expectedEditable, deserialized.Editable);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LinkType
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
            Editable = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LinkType
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
        };

        Assert.Null(model.Editable);
        Assert.False(model.RawData.ContainsKey("editable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LinkType
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LinkType
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",

            // Null should be interpreted as omitted for these properties
            Editable = null,
        };

        Assert.Null(model.Editable);
        Assert.False(model.RawData.ContainsKey("editable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LinkType
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",

            // Null should be interpreted as omitted for these properties
            Editable = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LinkType
        {
            Inward = "is (partially) paid for by",
            Name = "Paid",
            Outward = "(partially) pays for",
            Editable = false,
        };

        LinkType copied = new(model);

        Assert.Equal(model, copied);
    }
}
