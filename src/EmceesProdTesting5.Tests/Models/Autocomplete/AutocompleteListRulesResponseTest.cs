using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Autocomplete;

namespace EmceesProdTesting5.Tests.Models.Autocomplete;

public class AutocompleteListRulesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListRulesResponse
        {
            ID = "2",
            Name = "Rule one",
            Active = true,
            Description = "Useful rule.",
        };

        string expectedID = "2";
        string expectedName = "Rule one";
        bool expectedActive = true;
        string expectedDescription = "Useful rule.";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListRulesResponse
        {
            ID = "2",
            Name = "Rule one",
            Active = true,
            Description = "Useful rule.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListRulesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListRulesResponse
        {
            ID = "2",
            Name = "Rule one",
            Active = true,
            Description = "Useful rule.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListRulesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedName = "Rule one";
        bool expectedActive = true;
        string expectedDescription = "Useful rule.";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListRulesResponse
        {
            ID = "2",
            Name = "Rule one",
            Active = true,
            Description = "Useful rule.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutocompleteListRulesResponse { ID = "2", Name = "Rule one" };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutocompleteListRulesResponse { ID = "2", Name = "Rule one" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AutocompleteListRulesResponse
        {
            ID = "2",
            Name = "Rule one",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Description = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutocompleteListRulesResponse
        {
            ID = "2",
            Name = "Rule one",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListRulesResponse
        {
            ID = "2",
            Name = "Rule one",
            Active = true,
            Description = "Useful rule.",
        };

        AutocompleteListRulesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
