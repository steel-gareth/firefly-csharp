using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<
        AutocompleteListCategoriesResponse,
        AutocompleteListCategoriesResponseFromRaw
    >)
)]
public sealed record class AutocompleteListCategoriesResponse : JsonModel
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
    /// Name of the category found by an auto-complete search.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public AutocompleteListCategoriesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListCategoriesResponse(
        AutocompleteListCategoriesResponse autocompleteListCategoriesResponse
    )
        : base(autocompleteListCategoriesResponse) { }
#pragma warning restore CS8618

    public AutocompleteListCategoriesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListCategoriesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListCategoriesResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListCategoriesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListCategoriesResponseFromRaw : IFromRawJson<AutocompleteListCategoriesResponse>
{
    /// <inheritdoc/>
    public AutocompleteListCategoriesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListCategoriesResponse.FromRawUnchecked(rawData);
}
