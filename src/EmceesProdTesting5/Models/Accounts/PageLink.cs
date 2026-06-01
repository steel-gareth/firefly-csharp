using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<PageLink, PageLinkFromRaw>))]
public sealed record class PageLink : JsonModel
{
    public string? First
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("first");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("first", value);
        }
    }

    public string? Last
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("last", value);
        }
    }

    public string? Next
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next");
        }
        init { this._rawData.Set("next", value); }
    }

    public string? Prev
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prev");
        }
        init { this._rawData.Set("prev", value); }
    }

    public string? Self
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("self");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("self", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.First;
        _ = this.Last;
        _ = this.Next;
        _ = this.Prev;
        _ = this.Self;
    }

    public PageLink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PageLink(PageLink pageLink)
        : base(pageLink) { }
#pragma warning restore CS8618

    public PageLink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PageLink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PageLinkFromRaw.FromRawUnchecked"/>
    public static PageLink FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PageLinkFromRaw : IFromRawJson<PageLink>
{
    /// <inheritdoc/>
    public PageLink FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PageLink.FromRawUnchecked(rawData);
}
