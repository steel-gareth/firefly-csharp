using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Pets;

namespace EmceesProdTesting5.Tests.Models.Pets;

public class CategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Category { ID = 1, Name = "Dogs" };

        long expectedID = 1;
        string expectedName = "Dogs";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Category { ID = 1, Name = "Dogs" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Category>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Category { ID = 1, Name = "Dogs" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Category>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedID = 1;
        string expectedName = "Dogs";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Category { ID = 1, Name = "Dogs" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Category { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Category { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Category
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Category
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Category { ID = 1, Name = "Dogs" };

        Category copied = new(model);

        Assert.Equal(model, copied);
    }
}
