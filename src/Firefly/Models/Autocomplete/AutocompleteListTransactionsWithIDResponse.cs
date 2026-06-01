using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<
        AutocompleteListTransactionsWithIDResponse,
        AutocompleteListTransactionsWithIDResponseFromRaw
    >)
)]
public sealed record class AutocompleteListTransactionsWithIDResponse : JsonModel
{
    /// <summary>
    /// The ID of a transaction journal (basically a single split).
    /// </summary>
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
    /// Transaction description with ID in the name.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Transaction description with ID in the name.
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
    /// The ID of the underlying transaction group.
    /// </summary>
    public string? TransactionGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transaction_group_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transaction_group_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Name;
        _ = this.TransactionGroupID;
    }

    public AutocompleteListTransactionsWithIDResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListTransactionsWithIDResponse(
        AutocompleteListTransactionsWithIDResponse autocompleteListTransactionsWithIDResponse
    )
        : base(autocompleteListTransactionsWithIDResponse) { }
#pragma warning restore CS8618

    public AutocompleteListTransactionsWithIDResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListTransactionsWithIDResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListTransactionsWithIDResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListTransactionsWithIDResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListTransactionsWithIDResponseFromRaw
    : IFromRawJson<AutocompleteListTransactionsWithIDResponse>
{
    /// <inheritdoc/>
    public AutocompleteListTransactionsWithIDResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListTransactionsWithIDResponse.FromRawUnchecked(rawData);
}
