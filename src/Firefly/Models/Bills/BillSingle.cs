using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Bills;

[JsonConverter(typeof(JsonModelConverter<BillSingle, BillSingleFromRaw>))]
public sealed record class BillSingle : JsonModel
{
    public required BillRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BillRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public BillSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillSingle(BillSingle billSingle)
        : base(billSingle) { }
#pragma warning restore CS8618

    public BillSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillSingleFromRaw.FromRawUnchecked"/>
    public static BillSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BillSingle(BillRead data)
        : this()
    {
        this.Data = data;
    }
}

class BillSingleFromRaw : IFromRawJson<BillSingle>
{
    /// <inheritdoc/>
    public BillSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillSingle.FromRawUnchecked(rawData);
}
