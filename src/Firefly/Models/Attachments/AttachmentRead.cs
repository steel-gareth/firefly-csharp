using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Attachments;

[JsonConverter(typeof(JsonModelConverter<AttachmentRead, AttachmentReadFromRaw>))]
public sealed record class AttachmentRead : JsonModel
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

    public AttachmentRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttachmentRead(AttachmentRead attachmentRead)
        : base(attachmentRead) { }
#pragma warning restore CS8618

    public AttachmentRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachmentRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentReadFromRaw.FromRawUnchecked"/>
    public static AttachmentRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttachmentReadFromRaw : IFromRawJson<AttachmentRead>
{
    /// <inheritdoc/>
    public AttachmentRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AttachmentRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    /// <summary>
    /// ID of the model this attachment is linked to.
    /// </summary>
    public string? AttachableID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("attachable_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("attachable_id", value);
        }
    }

    /// <summary>
    /// The object class to which the attachment must be linked.
    /// </summary>
    public ApiEnum<string, AttachableType>? AttachableType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AttachableType>>(
                "attachable_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("attachable_type", value);
        }
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

    public string? DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("download_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("download_url", value);
        }
    }

    public string? Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    /// <summary>
    /// Hash of the file for basic duplicate detection.
    /// </summary>
    public string? Hash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hash");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hash", value);
        }
    }

    public string? Mime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mime", value);
        }
    }

    public string? Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("notes");
        }
        init { this._rawData.Set("notes", value); }
    }

    public int? Size
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("size", value);
        }
    }

    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
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

    public string? UploadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("upload_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("upload_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttachableID;
        this.AttachableType?.Validate();
        _ = this.CreatedAt;
        _ = this.DownloadUrl;
        _ = this.Filename;
        _ = this.Hash;
        _ = this.Mime;
        _ = this.Notes;
        _ = this.Size;
        _ = this.Title;
        _ = this.UpdatedAt;
        _ = this.UploadUrl;
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
}

class AttributesFromRaw : IFromRawJson<Attributes>
{
    /// <inheritdoc/>
    public Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attributes.FromRawUnchecked(rawData);
}
