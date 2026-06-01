using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Models.ObjectGroups;

[JsonConverter(typeof(JsonModelConverter<ObjectGroupListResponse, ObjectGroupListResponseFromRaw>))]
public sealed record class ObjectGroupListResponse : JsonModel
{
    public required IReadOnlyList<ObjectGroupRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ObjectGroupRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ObjectGroupRead>>(
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

    public ObjectGroupListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ObjectGroupListResponse(ObjectGroupListResponse objectGroupListResponse)
        : base(objectGroupListResponse) { }
#pragma warning restore CS8618

    public ObjectGroupListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ObjectGroupListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ObjectGroupListResponseFromRaw.FromRawUnchecked"/>
    public static ObjectGroupListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ObjectGroupListResponseFromRaw : IFromRawJson<ObjectGroupListResponse>
{
    /// <inheritdoc/>
    public ObjectGroupListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ObjectGroupListResponse.FromRawUnchecked(rawData);
}
