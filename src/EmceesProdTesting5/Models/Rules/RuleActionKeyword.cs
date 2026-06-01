using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Rules;

/// <summary>
/// The type of thing this action will do. A limited set is possible.
/// </summary>
[JsonConverter(typeof(RuleActionKeywordConverter))]
public enum RuleActionKeyword
{
    UserAction,
    SetCategory,
    ClearCategory,
    SetBudget,
    ClearBudget,
    AddTag,
    RemoveTag,
    RemoveAllTags,
    SetDescription,
    AppendDescription,
    PrependDescription,
    SetSourceAccount,
    SetDestinationAccount,
    SetNotes,
    AppendNotes,
    PrependNotes,
    ClearNotes,
    LinkToBill,
    ConvertWithdrawal,
    ConvertDeposit,
    ConvertTransfer,
    DeleteTransaction,
}

sealed class RuleActionKeywordConverter : JsonConverter<RuleActionKeyword>
{
    public override RuleActionKeyword Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_action" => RuleActionKeyword.UserAction,
            "set_category" => RuleActionKeyword.SetCategory,
            "clear_category" => RuleActionKeyword.ClearCategory,
            "set_budget" => RuleActionKeyword.SetBudget,
            "clear_budget" => RuleActionKeyword.ClearBudget,
            "add_tag" => RuleActionKeyword.AddTag,
            "remove_tag" => RuleActionKeyword.RemoveTag,
            "remove_all_tags" => RuleActionKeyword.RemoveAllTags,
            "set_description" => RuleActionKeyword.SetDescription,
            "append_description" => RuleActionKeyword.AppendDescription,
            "prepend_description" => RuleActionKeyword.PrependDescription,
            "set_source_account" => RuleActionKeyword.SetSourceAccount,
            "set_destination_account" => RuleActionKeyword.SetDestinationAccount,
            "set_notes" => RuleActionKeyword.SetNotes,
            "append_notes" => RuleActionKeyword.AppendNotes,
            "prepend_notes" => RuleActionKeyword.PrependNotes,
            "clear_notes" => RuleActionKeyword.ClearNotes,
            "link_to_bill" => RuleActionKeyword.LinkToBill,
            "convert_withdrawal" => RuleActionKeyword.ConvertWithdrawal,
            "convert_deposit" => RuleActionKeyword.ConvertDeposit,
            "convert_transfer" => RuleActionKeyword.ConvertTransfer,
            "delete_transaction" => RuleActionKeyword.DeleteTransaction,
            _ => (RuleActionKeyword)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RuleActionKeyword value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RuleActionKeyword.UserAction => "user_action",
                RuleActionKeyword.SetCategory => "set_category",
                RuleActionKeyword.ClearCategory => "clear_category",
                RuleActionKeyword.SetBudget => "set_budget",
                RuleActionKeyword.ClearBudget => "clear_budget",
                RuleActionKeyword.AddTag => "add_tag",
                RuleActionKeyword.RemoveTag => "remove_tag",
                RuleActionKeyword.RemoveAllTags => "remove_all_tags",
                RuleActionKeyword.SetDescription => "set_description",
                RuleActionKeyword.AppendDescription => "append_description",
                RuleActionKeyword.PrependDescription => "prepend_description",
                RuleActionKeyword.SetSourceAccount => "set_source_account",
                RuleActionKeyword.SetDestinationAccount => "set_destination_account",
                RuleActionKeyword.SetNotes => "set_notes",
                RuleActionKeyword.AppendNotes => "append_notes",
                RuleActionKeyword.PrependNotes => "prepend_notes",
                RuleActionKeyword.ClearNotes => "clear_notes",
                RuleActionKeyword.LinkToBill => "link_to_bill",
                RuleActionKeyword.ConvertWithdrawal => "convert_withdrawal",
                RuleActionKeyword.ConvertDeposit => "convert_deposit",
                RuleActionKeyword.ConvertTransfer => "convert_transfer",
                RuleActionKeyword.DeleteTransaction => "delete_transaction",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
