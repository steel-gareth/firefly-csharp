using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AttachmentArray, AttachmentArrayFromRaw>))]
public sealed record class AttachmentArray : JsonModel
{
    public required IReadOnlyList<AttachmentRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AttachmentRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AttachmentRead>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        this.Meta.Validate();
    }

    public AttachmentArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttachmentArray(AttachmentArray attachmentArray)
        : base(attachmentArray) { }
#pragma warning restore CS8618

    public AttachmentArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachmentArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentArrayFromRaw.FromRawUnchecked"/>
    public static AttachmentArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttachmentArrayFromRaw : IFromRawJson<AttachmentArray>
{
    /// <inheritdoc/>
    public AttachmentArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AttachmentArray.FromRawUnchecked(rawData);
}
