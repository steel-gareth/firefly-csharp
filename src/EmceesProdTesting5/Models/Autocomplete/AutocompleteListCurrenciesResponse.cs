using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<
        AutocompleteListCurrenciesResponse,
        AutocompleteListCurrenciesResponseFromRaw
    >)
)]
public sealed record class AutocompleteListCurrenciesResponse : JsonModel
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
    /// Currency code.
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    public required int DecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("decimal_places");
        }
        init { this._rawData.Set("decimal_places", value); }
    }

    /// <summary>
    /// Currency name.
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

    public required string Symbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("symbol");
        }
        init { this._rawData.Set("symbol", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Code;
        _ = this.DecimalPlaces;
        _ = this.Name;
        _ = this.Symbol;
    }

    public AutocompleteListCurrenciesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListCurrenciesResponse(
        AutocompleteListCurrenciesResponse autocompleteListCurrenciesResponse
    )
        : base(autocompleteListCurrenciesResponse) { }
#pragma warning restore CS8618

    public AutocompleteListCurrenciesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListCurrenciesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListCurrenciesResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListCurrenciesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListCurrenciesResponseFromRaw : IFromRawJson<AutocompleteListCurrenciesResponse>
{
    /// <inheritdoc/>
    public AutocompleteListCurrenciesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListCurrenciesResponse.FromRawUnchecked(rawData);
}
