using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Autocomplete;

namespace Firefly.Tests.Models.Autocomplete;

public class AutocompleteBillTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteBill
        {
            ID = "2",
            Name = "Yearly bill",
            Active = true,
        };

        string expectedID = "2";
        string expectedName = "Yearly bill";
        bool expectedActive = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedActive, model.Active);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteBill
        {
            ID = "2",
            Name = "Yearly bill",
            Active = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteBill>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteBill
        {
            ID = "2",
            Name = "Yearly bill",
            Active = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteBill>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedName = "Yearly bill";
        bool expectedActive = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedActive, deserialized.Active);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteBill
        {
            ID = "2",
            Name = "Yearly bill",
            Active = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutocompleteBill { ID = "2", Name = "Yearly bill" };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutocompleteBill { ID = "2", Name = "Yearly bill" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AutocompleteBill
        {
            ID = "2",
            Name = "Yearly bill",

            // Null should be interpreted as omitted for these properties
            Active = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutocompleteBill
        {
            ID = "2",
            Name = "Yearly bill",

            // Null should be interpreted as omitted for these properties
            Active = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteBill
        {
            ID = "2",
            Name = "Yearly bill",
            Active = true,
        };

        AutocompleteBill copied = new(model);

        Assert.Equal(model, copied);
    }
}
