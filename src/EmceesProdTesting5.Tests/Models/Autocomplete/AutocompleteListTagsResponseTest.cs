using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Autocomplete;

namespace EmceesProdTesting5.Tests.Models.Autocomplete;

public class AutocompleteListTagsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListTagsResponse
        {
            ID = "2",
            Name = "too-expensive-tag-example",
            Tag = "too-expensive-tag-example",
        };

        string expectedID = "2";
        string expectedName = "too-expensive-tag-example";
        string expectedTag = "too-expensive-tag-example";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTag, model.Tag);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListTagsResponse
        {
            ID = "2",
            Name = "too-expensive-tag-example",
            Tag = "too-expensive-tag-example",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListTagsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListTagsResponse
        {
            ID = "2",
            Name = "too-expensive-tag-example",
            Tag = "too-expensive-tag-example",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListTagsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedName = "too-expensive-tag-example";
        string expectedTag = "too-expensive-tag-example";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTag, deserialized.Tag);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListTagsResponse
        {
            ID = "2",
            Name = "too-expensive-tag-example",
            Tag = "too-expensive-tag-example",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListTagsResponse
        {
            ID = "2",
            Name = "too-expensive-tag-example",
            Tag = "too-expensive-tag-example",
        };

        AutocompleteListTagsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
