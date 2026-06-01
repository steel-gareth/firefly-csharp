using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<
        AutocompleteListTransactionTypesResponse,
        AutocompleteListTransactionTypesResponseFromRaw
    >)
)]
public sealed record class AutocompleteListTransactionTypesResponse : JsonModel
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
    /// Type of the object found by an auto-complete search.
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
    /// Name of the object found by an auto-complete search.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Type;
    }

    public AutocompleteListTransactionTypesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListTransactionTypesResponse(
        AutocompleteListTransactionTypesResponse autocompleteListTransactionTypesResponse
    )
        : base(autocompleteListTransactionTypesResponse) { }
#pragma warning restore CS8618

    public AutocompleteListTransactionTypesResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListTransactionTypesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListTransactionTypesResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListTransactionTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListTransactionTypesResponseFromRaw
    : IFromRawJson<AutocompleteListTransactionTypesResponse>
{
    /// <inheritdoc/>
    public AutocompleteListTransactionTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListTransactionTypesResponse.FromRawUnchecked(rawData);
}
