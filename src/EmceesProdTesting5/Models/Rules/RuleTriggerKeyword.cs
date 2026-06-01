using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Rules;

/// <summary>
/// The type of thing this trigger responds to. A limited set is possible
/// </summary>
[JsonConverter(typeof(RuleTriggerKeywordConverter))]
public enum RuleTriggerKeyword
{
    FromAccountStarts,
    FromAccountEnds,
    FromAccountIs,
    FromAccountContains,
    ToAccountStarts,
    ToAccountEnds,
    ToAccountIs,
    ToAccountContains,
    AmountLess,
    AmountExactly,
    AmountMore,
    DescriptionStarts,
    DescriptionEnds,
    DescriptionContains,
    DescriptionIs,
    TransactionType,
    CategoryIs,
    BudgetIs,
    TagIs,
    CurrencyIs,
    HasAttachments,
    HasNoCategory,
    HasAnyCategory,
    HasNoBudget,
    HasAnyBudget,
    HasNoTag,
    HasAnyTag,
    NotesContains,
    NotesStarts,
    NotesEnd,
    NotesAre,
    NoNotes,
    AnyNotes,
    SourceAccountIs,
    DestinationAccountIs,
    SourceAccountStarts,
}

sealed class RuleTriggerKeywordConverter : JsonConverter<RuleTriggerKeyword>
{
    public override RuleTriggerKeyword Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "from_account_starts" => RuleTriggerKeyword.FromAccountStarts,
            "from_account_ends" => RuleTriggerKeyword.FromAccountEnds,
            "from_account_is" => RuleTriggerKeyword.FromAccountIs,
            "from_account_contains" => RuleTriggerKeyword.FromAccountContains,
            "to_account_starts" => RuleTriggerKeyword.ToAccountStarts,
            "to_account_ends" => RuleTriggerKeyword.ToAccountEnds,
            "to_account_is" => RuleTriggerKeyword.ToAccountIs,
            "to_account_contains" => RuleTriggerKeyword.ToAccountContains,
            "amount_less" => RuleTriggerKeyword.AmountLess,
            "amount_exactly" => RuleTriggerKeyword.AmountExactly,
            "amount_more" => RuleTriggerKeyword.AmountMore,
            "description_starts" => RuleTriggerKeyword.DescriptionStarts,
            "description_ends" => RuleTriggerKeyword.DescriptionEnds,
            "description_contains" => RuleTriggerKeyword.DescriptionContains,
            "description_is" => RuleTriggerKeyword.DescriptionIs,
            "transaction_type" => RuleTriggerKeyword.TransactionType,
            "category_is" => RuleTriggerKeyword.CategoryIs,
            "budget_is" => RuleTriggerKeyword.BudgetIs,
            "tag_is" => RuleTriggerKeyword.TagIs,
            "currency_is" => RuleTriggerKeyword.CurrencyIs,
            "has_attachments" => RuleTriggerKeyword.HasAttachments,
            "has_no_category" => RuleTriggerKeyword.HasNoCategory,
            "has_any_category" => RuleTriggerKeyword.HasAnyCategory,
            "has_no_budget" => RuleTriggerKeyword.HasNoBudget,
            "has_any_budget" => RuleTriggerKeyword.HasAnyBudget,
            "has_no_tag" => RuleTriggerKeyword.HasNoTag,
            "has_any_tag" => RuleTriggerKeyword.HasAnyTag,
            "notes_contains" => RuleTriggerKeyword.NotesContains,
            "notes_starts" => RuleTriggerKeyword.NotesStarts,
            "notes_end" => RuleTriggerKeyword.NotesEnd,
            "notes_are" => RuleTriggerKeyword.NotesAre,
            "no_notes" => RuleTriggerKeyword.NoNotes,
            "any_notes" => RuleTriggerKeyword.AnyNotes,
            "source_account_is" => RuleTriggerKeyword.SourceAccountIs,
            "destination_account_is" => RuleTriggerKeyword.DestinationAccountIs,
            "source_account_starts" => RuleTriggerKeyword.SourceAccountStarts,
            _ => (RuleTriggerKeyword)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RuleTriggerKeyword value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RuleTriggerKeyword.FromAccountStarts => "from_account_starts",
                RuleTriggerKeyword.FromAccountEnds => "from_account_ends",
                RuleTriggerKeyword.FromAccountIs => "from_account_is",
                RuleTriggerKeyword.FromAccountContains => "from_account_contains",
                RuleTriggerKeyword.ToAccountStarts => "to_account_starts",
                RuleTriggerKeyword.ToAccountEnds => "to_account_ends",
                RuleTriggerKeyword.ToAccountIs => "to_account_is",
                RuleTriggerKeyword.ToAccountContains => "to_account_contains",
                RuleTriggerKeyword.AmountLess => "amount_less",
                RuleTriggerKeyword.AmountExactly => "amount_exactly",
                RuleTriggerKeyword.AmountMore => "amount_more",
                RuleTriggerKeyword.DescriptionStarts => "description_starts",
                RuleTriggerKeyword.DescriptionEnds => "description_ends",
                RuleTriggerKeyword.DescriptionContains => "description_contains",
                RuleTriggerKeyword.DescriptionIs => "description_is",
                RuleTriggerKeyword.TransactionType => "transaction_type",
                RuleTriggerKeyword.CategoryIs => "category_is",
                RuleTriggerKeyword.BudgetIs => "budget_is",
                RuleTriggerKeyword.TagIs => "tag_is",
                RuleTriggerKeyword.CurrencyIs => "currency_is",
                RuleTriggerKeyword.HasAttachments => "has_attachments",
                RuleTriggerKeyword.HasNoCategory => "has_no_category",
                RuleTriggerKeyword.HasAnyCategory => "has_any_category",
                RuleTriggerKeyword.HasNoBudget => "has_no_budget",
                RuleTriggerKeyword.HasAnyBudget => "has_any_budget",
                RuleTriggerKeyword.HasNoTag => "has_no_tag",
                RuleTriggerKeyword.HasAnyTag => "has_any_tag",
                RuleTriggerKeyword.NotesContains => "notes_contains",
                RuleTriggerKeyword.NotesStarts => "notes_starts",
                RuleTriggerKeyword.NotesEnd => "notes_end",
                RuleTriggerKeyword.NotesAre => "notes_are",
                RuleTriggerKeyword.NoNotes => "no_notes",
                RuleTriggerKeyword.AnyNotes => "any_notes",
                RuleTriggerKeyword.SourceAccountIs => "source_account_is",
                RuleTriggerKeyword.DestinationAccountIs => "destination_account_is",
                RuleTriggerKeyword.SourceAccountStarts => "source_account_starts",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
