using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Attachments;

namespace Firefly.Tests.Models.Attachments;

public class ObjectLinkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ObjectLink
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };

        V0 expectedO0 = new() { Rel = "self", Uri = "/OBJECTS/1" };
        string expectedSelf = "https://demo.firefly-iii.org/api/v1/OBJECTS/1";

        Assert.Equal(expectedO0, model.O0);
        Assert.Equal(expectedSelf, model.Self);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ObjectLink
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectLink>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ObjectLink
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ObjectLink>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        V0 expectedO0 = new() { Rel = "self", Uri = "/OBJECTS/1" };
        string expectedSelf = "https://demo.firefly-iii.org/api/v1/OBJECTS/1";

        Assert.Equal(expectedO0, deserialized.O0);
        Assert.Equal(expectedSelf, deserialized.Self);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ObjectLink
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ObjectLink { };

        Assert.Null(model.O0);
        Assert.False(model.RawData.ContainsKey("0"));
        Assert.Null(model.Self);
        Assert.False(model.RawData.ContainsKey("self"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ObjectLink { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ObjectLink
        {
            // Null should be interpreted as omitted for these properties
            O0 = null,
            Self = null,
        };

        Assert.Null(model.O0);
        Assert.False(model.RawData.ContainsKey("0"));
        Assert.Null(model.Self);
        Assert.False(model.RawData.ContainsKey("self"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ObjectLink
        {
            // Null should be interpreted as omitted for these properties
            O0 = null,
            Self = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ObjectLink
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };

        ObjectLink copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class V0Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new V0 { Rel = "self", Uri = "/OBJECTS/1" };

        string expectedRel = "self";
        string expectedUri = "/OBJECTS/1";

        Assert.Equal(expectedRel, model.Rel);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new V0 { Rel = "self", Uri = "/OBJECTS/1" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V0>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new V0 { Rel = "self", Uri = "/OBJECTS/1" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<V0>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedRel = "self";
        string expectedUri = "/OBJECTS/1";

        Assert.Equal(expectedRel, deserialized.Rel);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new V0 { Rel = "self", Uri = "/OBJECTS/1" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new V0 { };

        Assert.Null(model.Rel);
        Assert.False(model.RawData.ContainsKey("rel"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new V0 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new V0
        {
            // Null should be interpreted as omitted for these properties
            Rel = null,
            Uri = null,
        };

        Assert.Null(model.Rel);
        Assert.False(model.RawData.ContainsKey("rel"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new V0
        {
            // Null should be interpreted as omitted for these properties
            Rel = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new V0 { Rel = "self", Uri = "/OBJECTS/1" };

        V0 copied = new(model);

        Assert.Equal(model, copied);
    }
}
