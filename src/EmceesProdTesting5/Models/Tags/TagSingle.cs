using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Tags;

[JsonConverter(typeof(JsonModelConverter<TagSingle, TagSingleFromRaw>))]
public sealed record class TagSingle : JsonModel
{
    public required TagRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TagRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public TagSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TagSingle(TagSingle tagSingle)
        : base(tagSingle) { }
#pragma warning restore CS8618

    public TagSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TagSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TagSingleFromRaw.FromRawUnchecked"/>
    public static TagSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TagSingle(TagRead data)
        : this()
    {
        this.Data = data;
    }
}

class TagSingleFromRaw : IFromRawJson<TagSingle>
{
    /// <inheritdoc/>
    public TagSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TagSingle.FromRawUnchecked(rawData);
}
