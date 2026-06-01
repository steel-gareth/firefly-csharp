using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.ObjectGroups;

[JsonConverter(typeof(JsonModelConverter<ObjectGroupSingle, ObjectGroupSingleFromRaw>))]
public sealed record class ObjectGroupSingle : JsonModel
{
    public required ObjectGroupRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ObjectGroupRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public ObjectGroupSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGroupSingle(ObjectGroupSingle objectGroupSingle)
        : base(objectGroupSingle) { }
#pragma warning restore CS8618

    public ObjectGroupSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGroupSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectGroupSingleFromRaw.FromRawUnchecked"/>
    public static ObjectGroupSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ObjectGroupSingle(ObjectGroupRead data)
        : this()
    {
        this.Data = data;
    }
}

class ObjectGroupSingleFromRaw : IFromRawJson<ObjectGroupSingle>
{
    /// <inheritdoc/>
    public ObjectGroupSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ObjectGroupSingle.FromRawUnchecked(rawData);
}
