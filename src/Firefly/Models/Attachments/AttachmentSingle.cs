using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Attachments;

[JsonConverter(typeof(JsonModelConverter<AttachmentSingle, AttachmentSingleFromRaw>))]
public sealed record class AttachmentSingle : JsonModel
{
    public required AttachmentRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AttachmentRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public AttachmentSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttachmentSingle(AttachmentSingle attachmentSingle)
        : base(attachmentSingle) { }
#pragma warning restore CS8618

    public AttachmentSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachmentSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentSingleFromRaw.FromRawUnchecked"/>
    public static AttachmentSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AttachmentSingle(AttachmentRead data)
        : this()
    {
        this.Data = data;
    }
}

class AttachmentSingleFromRaw : IFromRawJson<AttachmentSingle>
{
    /// <inheritdoc/>
    public AttachmentSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AttachmentSingle.FromRawUnchecked(rawData);
}
