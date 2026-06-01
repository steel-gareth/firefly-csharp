using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Models.LinkTypes;

[JsonConverter(typeof(JsonModelConverter<LinkTypeListResponse, LinkTypeListResponseFromRaw>))]
public sealed record class LinkTypeListResponse : JsonModel
{
    public required IReadOnlyList<LinkTypeRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LinkTypeRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LinkTypeRead>>(
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

    public LinkTypeListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkTypeListResponse(LinkTypeListResponse linkTypeListResponse)
        : base(linkTypeListResponse) { }
#pragma warning restore CS8618

    public LinkTypeListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkTypeListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkTypeListResponseFromRaw.FromRawUnchecked"/>
    public static LinkTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkTypeListResponseFromRaw : IFromRawJson<LinkTypeListResponse>
{
    /// <inheritdoc/>
    public LinkTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LinkTypeListResponse.FromRawUnchecked(rawData);
}
