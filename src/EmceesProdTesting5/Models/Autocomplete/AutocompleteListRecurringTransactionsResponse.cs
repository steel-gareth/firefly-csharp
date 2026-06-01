using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<
        AutocompleteListRecurringTransactionsResponse,
        AutocompleteListRecurringTransactionsResponseFromRaw
    >)
)]
public sealed record class AutocompleteListRecurringTransactionsResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Name of the recurrence found by an auto-complete search.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Is the recurring transaction active or not?
    /// </summary>
    public bool? Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// Description of the recurrence found by auto-complete.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Active;
        _ = this.Description;
    }

    public AutocompleteListRecurringTransactionsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListRecurringTransactionsResponse(
        AutocompleteListRecurringTransactionsResponse autocompleteListRecurringTransactionsResponse
    )
        : base(autocompleteListRecurringTransactionsResponse) { }
#pragma warning restore CS8618

    public AutocompleteListRecurringTransactionsResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListRecurringTransactionsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListRecurringTransactionsResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListRecurringTransactionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListRecurringTransactionsResponseFromRaw
    : IFromRawJson<AutocompleteListRecurringTransactionsResponse>
{
    /// <inheritdoc/>
    public AutocompleteListRecurringTransactionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListRecurringTransactionsResponse.FromRawUnchecked(rawData);
}
