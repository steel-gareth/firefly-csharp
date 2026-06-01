using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Models.Tags;

[JsonConverter(typeof(JsonModelConverter<TagListResponse, TagListResponseFromRaw>))]
public sealed record class TagListResponse : JsonModel
{
    public required IReadOnlyList<TagRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TagRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TagRead>>(
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

    public TagListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TagListResponse(TagListResponse tagListResponse)
        : base(tagListResponse) { }
#pragma warning restore CS8618

    public TagListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TagListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TagListResponseFromRaw.FromRawUnchecked"/>
    public static TagListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TagListResponseFromRaw : IFromRawJson<TagListResponse>
{
    /// <inheritdoc/>
    public TagListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TagListResponse.FromRawUnchecked(rawData);
}
