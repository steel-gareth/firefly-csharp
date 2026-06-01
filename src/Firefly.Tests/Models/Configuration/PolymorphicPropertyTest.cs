using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Configuration;

namespace Firefly.Tests.Models.Configuration;

public class PolymorphicPropertyTest : TestBase
{
    [Fact]
    public void BoolValidationWorks()
    {
        PolymorphicProperty value = true;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        PolymorphicProperty value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks()
    {
        PolymorphicProperty value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        PolymorphicProperty value = new(["EUR"]);
        value.Validate();
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        PolymorphicProperty value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PolymorphicProperty>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        PolymorphicProperty value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PolymorphicProperty>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        PolymorphicProperty value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PolymorphicProperty>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        PolymorphicProperty value = new(["EUR"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PolymorphicProperty>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
