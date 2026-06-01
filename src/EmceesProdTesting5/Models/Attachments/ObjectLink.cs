using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Attachments;

[JsonConverter(typeof(JsonModelConverter<ObjectLink, ObjectLinkFromRaw>))]
public sealed record class ObjectLink : JsonModel
{
    public V0? O0
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<V0>("0");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("0", value);
        }
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
        this.O0?.Validate();
        _ = this.Self;
    }

    public ObjectLink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectLink(ObjectLink objectLink)
        : base(objectLink) { }
#pragma warning restore CS8618

    public ObjectLink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectLink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectLinkFromRaw.FromRawUnchecked"/>
    public static ObjectLink FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectLinkFromRaw : IFromRawJson<ObjectLink>
{
    /// <inheritdoc/>
    public ObjectLink FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ObjectLink.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<V0, V0FromRaw>))]
public sealed record class V0 : JsonModel
{
    public string? Rel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rel", value);
        }
    }

    public string? Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Rel;
        _ = this.Uri;
    }

    public V0() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public V0(V0 v0)
        : base(v0) { }
#pragma warning restore CS8618

    public V0(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    V0(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="V0FromRaw.FromRawUnchecked"/>
    public static V0 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class V0FromRaw : IFromRawJson<V0>
{
    /// <inheritdoc/>
    public V0 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        V0.FromRawUnchecked(rawData);
}
