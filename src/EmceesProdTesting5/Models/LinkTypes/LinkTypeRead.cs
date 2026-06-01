using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Models.LinkTypes;

[JsonConverter(typeof(JsonModelConverter<LinkTypeRead, LinkTypeReadFromRaw>))]
public sealed record class LinkTypeRead : JsonModel
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

    public required LinkType Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LinkType>("attributes");
        }
        init { this._rawData.Set("attributes", value); }
    }

    public required ObjectLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ObjectLink>("links");
        }
        init { this._rawData.Set("links", value); }
    }

    /// <summary>
    /// Immutable value
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
        this.Attributes.Validate();
        this.Links.Validate();
        _ = this.Type;
    }

    public LinkTypeRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkTypeRead(LinkTypeRead linkTypeRead)
        : base(linkTypeRead) { }
#pragma warning restore CS8618

    public LinkTypeRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkTypeRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkTypeReadFromRaw.FromRawUnchecked"/>
    public static LinkTypeRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkTypeReadFromRaw : IFromRawJson<LinkTypeRead>
{
    /// <inheritdoc/>
    public LinkTypeRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LinkTypeRead.FromRawUnchecked(rawData);
}
