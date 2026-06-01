using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Autocomplete;

namespace Firefly.Tests.Models.Autocomplete;

public class AutocompleteListObjectGroupsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListObjectGroupsResponse
        {
            ID = "2",
            Name = "Object Group one",
            Title = "Object Group one",
        };

        string expectedID = "2";
        string expectedName = "Object Group one";
        string expectedTitle = "Object Group one";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListObjectGroupsResponse
        {
            ID = "2",
            Name = "Object Group one",
            Title = "Object Group one",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListObjectGroupsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListObjectGroupsResponse
        {
            ID = "2",
            Name = "Object Group one",
            Title = "Object Group one",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListObjectGroupsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedName = "Object Group one";
        string expectedTitle = "Object Group one";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListObjectGroupsResponse
        {
            ID = "2",
            Name = "Object Group one",
            Title = "Object Group one",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListObjectGroupsResponse
        {
            ID = "2",
            Name = "Object Group one",
            Title = "Object Group one",
        };

        AutocompleteListObjectGroupsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
