using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.LinkTypes;

[JsonConverter(typeof(JsonModelConverter<LinkType, LinkTypeFromRaw>))]
public sealed record class LinkType : JsonModel
{
    public required string Inward
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("inward");
        }
        init { this._rawData.Set("inward", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string Outward
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("outward");
        }
        init { this._rawData.Set("outward", value); }
    }

    public bool? Editable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("editable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("editable", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Inward;
        _ = this.Name;
        _ = this.Outward;
        _ = this.Editable;
    }

    public LinkType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LinkType(LinkType linkType)
        : base(linkType) { }
#pragma warning restore CS8618

    public LinkType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkTypeFromRaw.FromRawUnchecked"/>
    public static LinkType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkTypeFromRaw : IFromRawJson<LinkType>
{
    /// <inheritdoc/>
    public LinkType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LinkType.FromRawUnchecked(rawData);
}
