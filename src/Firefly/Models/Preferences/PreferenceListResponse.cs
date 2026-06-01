using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Models.Preferences;

[JsonConverter(typeof(JsonModelConverter<PreferenceListResponse, PreferenceListResponseFromRaw>))]
public sealed record class PreferenceListResponse : JsonModel
{
    public required IReadOnlyList<PreferenceRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PreferenceRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PreferenceRead>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PageLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PageLink>("links");
        }
        init { this._rawData.Set("links", value); }
    }

    public required Meta Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>("meta");
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Links.Validate();
        this.Meta.Validate();
    }

    public PreferenceListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceListResponse(PreferenceListResponse preferenceListResponse)
        : base(preferenceListResponse) { }
#pragma warning restore CS8618

    public PreferenceListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceListResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceListResponseFromRaw : IFromRawJson<PreferenceListResponse>
{
    /// <inheritdoc/>
    public PreferenceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceListResponse.FromRawUnchecked(rawData);
}
