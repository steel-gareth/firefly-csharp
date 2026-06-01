using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<AutocompleteListTagsResponse, AutocompleteListTagsResponseFromRaw>)
)]
public sealed record class AutocompleteListTagsResponse : JsonModel
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
    /// Name of the tag found by an auto-complete search.
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
    /// Name of the tag found by an auto-complete search.
    /// </summary>
    public required string Tag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tag");
        }
        init { this._rawData.Set("tag", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Tag;
    }

    public AutocompleteListTagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListTagsResponse(AutocompleteListTagsResponse autocompleteListTagsResponse)
        : base(autocompleteListTagsResponse) { }
#pragma warning restore CS8618

    public AutocompleteListTagsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListTagsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListTagsResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListTagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListTagsResponseFromRaw : IFromRawJson<AutocompleteListTagsResponse>
{
    /// <inheritdoc/>
    public AutocompleteListTagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListTagsResponse.FromRawUnchecked(rawData);
}
