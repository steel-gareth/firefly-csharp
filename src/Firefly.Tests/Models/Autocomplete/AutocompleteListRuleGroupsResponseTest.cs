using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Autocomplete;

namespace Firefly.Tests.Models.Autocomplete;

public class AutocompleteListRuleGroupsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListRuleGroupsResponse
        {
            ID = "2",
            Name = "Rule group one",
            Active = true,
            Description = "Some rule group.",
        };

        string expectedID = "2";
        string expectedName = "Rule group one";
        bool expectedActive = true;
        string expectedDescription = "Some rule group.";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListRuleGroupsResponse
        {
            ID = "2",
            Name = "Rule group one",
            Active = true,
            Description = "Some rule group.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListRuleGroupsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListRuleGroupsResponse
        {
            ID = "2",
            Name = "Rule group one",
            Active = true,
            Description = "Some rule group.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListRuleGroupsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedName = "Rule group one";
        bool expectedActive = true;
        string expectedDescription = "Some rule group.";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListRuleGroupsResponse
        {
            ID = "2",
            Name = "Rule group one",
            Active = true,
            Description = "Some rule group.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutocompleteListRuleGroupsResponse { ID = "2", Name = "Rule group one" };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutocompleteListRuleGroupsResponse { ID = "2", Name = "Rule group one" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AutocompleteListRuleGroupsResponse
        {
            ID = "2",
            Name = "Rule group one",

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
        var model = new AutocompleteListRuleGroupsResponse
        {
            ID = "2",
            Name = "Rule group one",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListRuleGroupsResponse
        {
            ID = "2",
            Name = "Rule group one",
            Active = true,
            Description = "Some rule group.",
        };

        AutocompleteListRuleGroupsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
