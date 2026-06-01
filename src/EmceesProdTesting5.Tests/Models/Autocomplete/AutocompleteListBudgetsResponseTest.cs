using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Autocomplete;

namespace EmceesProdTesting5.Tests.Models.Autocomplete;

public class AutocompleteListBudgetsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListBudgetsResponse
        {
            ID = "2",
            Name = "Groceries",
            Active = true,
        };

        string expectedID = "2";
        string expectedName = "Groceries";
        bool expectedActive = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedActive, model.Active);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListBudgetsResponse
        {
            ID = "2",
            Name = "Groceries",
            Active = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListBudgetsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListBudgetsResponse
        {
            ID = "2",
            Name = "Groceries",
            Active = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListBudgetsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedName = "Groceries";
        bool expectedActive = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedActive, deserialized.Active);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListBudgetsResponse
        {
            ID = "2",
            Name = "Groceries",
            Active = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutocompleteListBudgetsResponse { ID = "2", Name = "Groceries" };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutocompleteListBudgetsResponse { ID = "2", Name = "Groceries" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AutocompleteListBudgetsResponse
        {
            ID = "2",
            Name = "Groceries",

            // Null should be interpreted as omitted for these properties
            Active = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutocompleteListBudgetsResponse
        {
            ID = "2",
            Name = "Groceries",

            // Null should be interpreted as omitted for these properties
            Active = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListBudgetsResponse
        {
            ID = "2",
            Name = "Groceries",
            Active = true,
        };

        AutocompleteListBudgetsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
