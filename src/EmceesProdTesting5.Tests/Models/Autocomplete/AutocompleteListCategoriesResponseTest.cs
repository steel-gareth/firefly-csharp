using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Autocomplete;

namespace EmceesProdTesting5.Tests.Models.Autocomplete;

public class AutocompleteListCategoriesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListCategoriesResponse { ID = "2", Name = "Category X" };

        string expectedID = "2";
        string expectedName = "Category X";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListCategoriesResponse { ID = "2", Name = "Category X" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListCategoriesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListCategoriesResponse { ID = "2", Name = "Category X" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListCategoriesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedName = "Category X";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListCategoriesResponse { ID = "2", Name = "Category X" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListCategoriesResponse { ID = "2", Name = "Category X" };

        AutocompleteListCategoriesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
