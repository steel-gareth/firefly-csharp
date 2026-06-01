using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Autocomplete;

namespace Firefly.Tests.Models.Autocomplete;

public class AutocompleteListTransactionsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteListTransactionsResponse
        {
            ID = "2",
            Description = "Transaction",
            Name = "Transaction",
            TransactionGroupID = "2",
        };

        string expectedID = "2";
        string expectedDescription = "Transaction";
        string expectedName = "Transaction";
        string expectedTransactionGroupID = "2";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTransactionGroupID, model.TransactionGroupID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteListTransactionsResponse
        {
            ID = "2",
            Description = "Transaction",
            Name = "Transaction",
            TransactionGroupID = "2",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListTransactionsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteListTransactionsResponse
        {
            ID = "2",
            Description = "Transaction",
            Name = "Transaction",
            TransactionGroupID = "2",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteListTransactionsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        string expectedDescription = "Transaction";
        string expectedName = "Transaction";
        string expectedTransactionGroupID = "2";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTransactionGroupID, deserialized.TransactionGroupID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteListTransactionsResponse
        {
            ID = "2",
            Description = "Transaction",
            Name = "Transaction",
            TransactionGroupID = "2",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutocompleteListTransactionsResponse
        {
            ID = "2",
            Description = "Transaction",
            Name = "Transaction",
        };

        Assert.Null(model.TransactionGroupID);
        Assert.False(model.RawData.ContainsKey("transaction_group_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutocompleteListTransactionsResponse
        {
            ID = "2",
            Description = "Transaction",
            Name = "Transaction",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AutocompleteListTransactionsResponse
        {
            ID = "2",
            Description = "Transaction",
            Name = "Transaction",

            // Null should be interpreted as omitted for these properties
            TransactionGroupID = null,
        };

        Assert.Null(model.TransactionGroupID);
        Assert.False(model.RawData.ContainsKey("transaction_group_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutocompleteListTransactionsResponse
        {
            ID = "2",
            Description = "Transaction",
            Name = "Transaction",

            // Null should be interpreted as omitted for these properties
            TransactionGroupID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteListTransactionsResponse
        {
            ID = "2",
            Description = "Transaction",
            Name = "Transaction",
            TransactionGroupID = "2",
        };

        AutocompleteListTransactionsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
