using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Attachments = Firefly.Models.Attachments;

namespace Firefly.Models.Tags;

[JsonConverter(typeof(JsonModelConverter<TagRead, TagReadFromRaw>))]
public sealed record class TagRead : JsonModel
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

    public required Attributes Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Attributes>("attributes");
        }
        init { this._rawData.Set("attributes", value); }
    }

    public required Attachments::ObjectLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Attachments::ObjectLink>("links");
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

    public TagRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TagRead(TagRead tagRead)
        : base(tagRead) { }
#pragma warning restore CS8618

    public TagRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TagRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TagReadFromRaw.FromRawUnchecked"/>
    public static TagRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TagReadFromRaw : IFromRawJson<TagRead>
{
    /// <inheritdoc/>
    public TagRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TagRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    /// <summary>
    /// The tag
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

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// The date to which the tag is applicable.
    /// </summary>
    public string? Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("date");
        }
        init { this._rawData.Set("date", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Latitude of the tag's location, if applicable. Can be used to draw a map.
    /// </summary>
    public double? Latitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("latitude");
        }
        init { this._rawData.Set("latitude", value); }
    }

    /// <summary>
    /// Latitude of the tag's location, if applicable. Can be used to draw a map.
    /// </summary>
    public double? Longitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("longitude");
        }
        init { this._rawData.Set("longitude", value); }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <summary>
    /// Zoom level for the map, if drawn. This to set the box right. Unfortunately
    /// this is a proprietary value because each map provider has different zoom levels.
    /// </summary>
    public int? ZoomLevel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("zoom_level");
        }
        init { this._rawData.Set("zoom_level", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Tag;
        _ = this.CreatedAt;
        _ = this.Date;
        _ = this.Description;
        _ = this.Latitude;
        _ = this.Longitude;
        _ = this.UpdatedAt;
        _ = this.ZoomLevel;
    }

    public Attributes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attributes(Attributes attributes)
        : base(attributes) { }
#pragma warning restore CS8618

    public Attributes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Attributes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttributesFromRaw.FromRawUnchecked"/>
    public static Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Attributes(string tag)
        : this()
    {
        this.Tag = tag;
    }
}

class AttributesFromRaw : IFromRawJson<Attributes>
{
    /// <inheritdoc/>
    public Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attributes.FromRawUnchecked(rawData);
}
