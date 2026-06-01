using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Models.Bills;

[JsonConverter(typeof(JsonModelConverter<BillArray, BillArrayFromRaw>))]
public sealed record class BillArray : JsonModel
{
    public required IReadOnlyList<BillRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BillRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BillRead>>(
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

    public BillArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillArray(BillArray billArray)
        : base(billArray) { }
#pragma warning restore CS8618

    public BillArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillArrayFromRaw.FromRawUnchecked"/>
    public static BillArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillArrayFromRaw : IFromRawJson<BillArray>
{
    /// <inheritdoc/>
    public BillArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillArray.FromRawUnchecked(rawData);
}
