using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Rules;

namespace Firefly.Tests.Models.Rules;

public class RuleActionKeywordTest : TestBase
{
    [Theory]
    [InlineData(RuleActionKeyword.UserAction)]
    [InlineData(RuleActionKeyword.SetCategory)]
    [InlineData(RuleActionKeyword.ClearCategory)]
    [InlineData(RuleActionKeyword.SetBudget)]
    [InlineData(RuleActionKeyword.ClearBudget)]
    [InlineData(RuleActionKeyword.AddTag)]
    [InlineData(RuleActionKeyword.RemoveTag)]
    [InlineData(RuleActionKeyword.RemoveAllTags)]
    [InlineData(RuleActionKeyword.SetDescription)]
    [InlineData(RuleActionKeyword.AppendDescription)]
    [InlineData(RuleActionKeyword.PrependDescription)]
    [InlineData(RuleActionKeyword.SetSourceAccount)]
    [InlineData(RuleActionKeyword.SetDestinationAccount)]
    [InlineData(RuleActionKeyword.SetNotes)]
    [InlineData(RuleActionKeyword.AppendNotes)]
    [InlineData(RuleActionKeyword.PrependNotes)]
    [InlineData(RuleActionKeyword.ClearNotes)]
    [InlineData(RuleActionKeyword.LinkToBill)]
    [InlineData(RuleActionKeyword.ConvertWithdrawal)]
    [InlineData(RuleActionKeyword.ConvertDeposit)]
    [InlineData(RuleActionKeyword.ConvertTransfer)]
    [InlineData(RuleActionKeyword.DeleteTransaction)]
    public void Validation_Works(RuleActionKeyword rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RuleActionKeyword> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RuleActionKeyword>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RuleActionKeyword.UserAction)]
    [InlineData(RuleActionKeyword.SetCategory)]
    [InlineData(RuleActionKeyword.ClearCategory)]
    [InlineData(RuleActionKeyword.SetBudget)]
    [InlineData(RuleActionKeyword.ClearBudget)]
    [InlineData(RuleActionKeyword.AddTag)]
    [InlineData(RuleActionKeyword.RemoveTag)]
    [InlineData(RuleActionKeyword.RemoveAllTags)]
    [InlineData(RuleActionKeyword.SetDescription)]
    [InlineData(RuleActionKeyword.AppendDescription)]
    [InlineData(RuleActionKeyword.PrependDescription)]
    [InlineData(RuleActionKeyword.SetSourceAccount)]
    [InlineData(RuleActionKeyword.SetDestinationAccount)]
    [InlineData(RuleActionKeyword.SetNotes)]
    [InlineData(RuleActionKeyword.AppendNotes)]
    [InlineData(RuleActionKeyword.PrependNotes)]
    [InlineData(RuleActionKeyword.ClearNotes)]
    [InlineData(RuleActionKeyword.LinkToBill)]
    [InlineData(RuleActionKeyword.ConvertWithdrawal)]
    [InlineData(RuleActionKeyword.ConvertDeposit)]
    [InlineData(RuleActionKeyword.ConvertTransfer)]
    [InlineData(RuleActionKeyword.DeleteTransaction)]
    public void SerializationRoundtrip_Works(RuleActionKeyword rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RuleActionKeyword> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RuleActionKeyword>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RuleActionKeyword>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RuleActionKeyword>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
