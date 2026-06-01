using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.LinkTypes;

[JsonConverter(typeof(JsonModelConverter<LinkTypeSingle, LinkTypeSingleFromRaw>))]
public sealed record class LinkTypeSingle : JsonModel
{
    public required LinkTypeRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LinkTypeRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public LinkTypeSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkTypeSingle(LinkTypeSingle linkTypeSingle)
        : base(linkTypeSingle) { }
#pragma warning restore CS8618

    public LinkTypeSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkTypeSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkTypeSingleFromRaw.FromRawUnchecked"/>
    public static LinkTypeSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LinkTypeSingle(LinkTypeRead data)
        : this()
    {
        this.Data = data;
    }
}

class LinkTypeSingleFromRaw : IFromRawJson<LinkTypeSingle>
{
    /// <inheritdoc/>
    public LinkTypeSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LinkTypeSingle.FromRawUnchecked(rawData);
}
