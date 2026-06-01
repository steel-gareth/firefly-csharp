using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<
        AutocompleteListObjectGroupsResponse,
        AutocompleteListObjectGroupsResponseFromRaw
    >)
)]
public sealed record class AutocompleteListObjectGroupsResponse : JsonModel
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
    /// Title of the object group found by an auto-complete search.
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
    /// Title of the object group found by an auto-complete search.
    /// </summary>
    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Title;
    }

    public AutocompleteListObjectGroupsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListObjectGroupsResponse(
        AutocompleteListObjectGroupsResponse autocompleteListObjectGroupsResponse
    )
        : base(autocompleteListObjectGroupsResponse) { }
#pragma warning restore CS8618

    public AutocompleteListObjectGroupsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListObjectGroupsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListObjectGroupsResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListObjectGroupsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListObjectGroupsResponseFromRaw
    : IFromRawJson<AutocompleteListObjectGroupsResponse>
{
    /// <inheritdoc/>
    public AutocompleteListObjectGroupsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListObjectGroupsResponse.FromRawUnchecked(rawData);
}
