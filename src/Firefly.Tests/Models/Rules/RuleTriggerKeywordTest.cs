using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Rules;

namespace Firefly.Tests.Models.Rules;

public class RuleTriggerKeywordTest : TestBase
{
    [Theory]
    [InlineData(RuleTriggerKeyword.FromAccountStarts)]
    [InlineData(RuleTriggerKeyword.FromAccountEnds)]
    [InlineData(RuleTriggerKeyword.FromAccountIs)]
    [InlineData(RuleTriggerKeyword.FromAccountContains)]
    [InlineData(RuleTriggerKeyword.ToAccountStarts)]
    [InlineData(RuleTriggerKeyword.ToAccountEnds)]
    [InlineData(RuleTriggerKeyword.ToAccountIs)]
    [InlineData(RuleTriggerKeyword.ToAccountContains)]
    [InlineData(RuleTriggerKeyword.AmountLess)]
    [InlineData(RuleTriggerKeyword.AmountExactly)]
    [InlineData(RuleTriggerKeyword.AmountMore)]
    [InlineData(RuleTriggerKeyword.DescriptionStarts)]
    [InlineData(RuleTriggerKeyword.DescriptionEnds)]
    [InlineData(RuleTriggerKeyword.DescriptionContains)]
    [InlineData(RuleTriggerKeyword.DescriptionIs)]
    [InlineData(RuleTriggerKeyword.TransactionType)]
    [InlineData(RuleTriggerKeyword.CategoryIs)]
    [InlineData(RuleTriggerKeyword.BudgetIs)]
    [InlineData(RuleTriggerKeyword.TagIs)]
    [InlineData(RuleTriggerKeyword.CurrencyIs)]
    [InlineData(RuleTriggerKeyword.HasAttachments)]
    [InlineData(RuleTriggerKeyword.HasNoCategory)]
    [InlineData(RuleTriggerKeyword.HasAnyCategory)]
    [InlineData(RuleTriggerKeyword.HasNoBudget)]
    [InlineData(RuleTriggerKeyword.HasAnyBudget)]
    [InlineData(RuleTriggerKeyword.HasNoTag)]
    [InlineData(RuleTriggerKeyword.HasAnyTag)]
    [InlineData(RuleTriggerKeyword.NotesContains)]
    [InlineData(RuleTriggerKeyword.NotesStarts)]
    [InlineData(RuleTriggerKeyword.NotesEnd)]
    [InlineData(RuleTriggerKeyword.NotesAre)]
    [InlineData(RuleTriggerKeyword.NoNotes)]
    [InlineData(RuleTriggerKeyword.AnyNotes)]
    [InlineData(RuleTriggerKeyword.SourceAccountIs)]
    [InlineData(RuleTriggerKeyword.DestinationAccountIs)]
    [InlineData(RuleTriggerKeyword.SourceAccountStarts)]
    public void Validation_Works(RuleTriggerKeyword rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RuleTriggerKeyword> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RuleTriggerKeyword>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RuleTriggerKeyword.FromAccountStarts)]
    [InlineData(RuleTriggerKeyword.FromAccountEnds)]
    [InlineData(RuleTriggerKeyword.FromAccountIs)]
    [InlineData(RuleTriggerKeyword.FromAccountContains)]
    [InlineData(RuleTriggerKeyword.ToAccountStarts)]
    [InlineData(RuleTriggerKeyword.ToAccountEnds)]
    [InlineData(RuleTriggerKeyword.ToAccountIs)]
    [InlineData(RuleTriggerKeyword.ToAccountContains)]
    [InlineData(RuleTriggerKeyword.AmountLess)]
    [InlineData(RuleTriggerKeyword.AmountExactly)]
    [InlineData(RuleTriggerKeyword.AmountMore)]
    [InlineData(RuleTriggerKeyword.DescriptionStarts)]
    [InlineData(RuleTriggerKeyword.DescriptionEnds)]
    [InlineData(RuleTriggerKeyword.DescriptionContains)]
    [InlineData(RuleTriggerKeyword.DescriptionIs)]
    [InlineData(RuleTriggerKeyword.TransactionType)]
    [InlineData(RuleTriggerKeyword.CategoryIs)]
    [InlineData(RuleTriggerKeyword.BudgetIs)]
    [InlineData(RuleTriggerKeyword.TagIs)]
    [InlineData(RuleTriggerKeyword.CurrencyIs)]
    [InlineData(RuleTriggerKeyword.HasAttachments)]
    [InlineData(RuleTriggerKeyword.HasNoCategory)]
    [InlineData(RuleTriggerKeyword.HasAnyCategory)]
    [InlineData(RuleTriggerKeyword.HasNoBudget)]
    [InlineData(RuleTriggerKeyword.HasAnyBudget)]
    [InlineData(RuleTriggerKeyword.HasNoTag)]
    [InlineData(RuleTriggerKeyword.HasAnyTag)]
    [InlineData(RuleTriggerKeyword.NotesContains)]
    [InlineData(RuleTriggerKeyword.NotesStarts)]
    [InlineData(RuleTriggerKeyword.NotesEnd)]
    [InlineData(RuleTriggerKeyword.NotesAre)]
    [InlineData(RuleTriggerKeyword.NoNotes)]
    [InlineData(RuleTriggerKeyword.AnyNotes)]
    [InlineData(RuleTriggerKeyword.SourceAccountIs)]
    [InlineData(RuleTriggerKeyword.DestinationAccountIs)]
    [InlineData(RuleTriggerKeyword.SourceAccountStarts)]
    public void SerializationRoundtrip_Works(RuleTriggerKeyword rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RuleTriggerKeyword> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RuleTriggerKeyword>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RuleTriggerKeyword>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RuleTriggerKeyword>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
