using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Autocomplete;

namespace EmceesProdTesting5.Tests.Models.Autocomplete;

public class AutocompleteListTransactionTypesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListTransactionTypesResponse
        {
            ID = "2",
            Name = "Withdrawal",
            Type = "Withdrawal",
        };

        string expectedID = "2";
        string expectedName = "Withdrawal";
        string expectedType = "Withdrawal";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListTransactionTypesResponse
        {
            ID = "2",
            Name = "Withdrawal",
            Type = "Withdrawal",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListTransactionTypesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListTransactionTypesResponse
        {
            ID = "2",
            Name = "Withdrawal",
            Type = "Withdrawal",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListTransactionTypesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedName = "Withdrawal";
        string expectedType = "Withdrawal";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListTransactionTypesResponse
        {
            ID = "2",
            Name = "Withdrawal",
            Type = "Withdrawal",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListTransactionTypesResponse
        {
            ID = "2",
            Name = "Withdrawal",
            Type = "Withdrawal",
        };

        AutocompleteListTransactionTypesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
