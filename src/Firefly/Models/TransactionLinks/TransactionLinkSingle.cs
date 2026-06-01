using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.TransactionLinks;

[JsonConverter(typeof(JsonModelConverter<TransactionLinkSingle, TransactionLinkSingleFromRaw>))]
public sealed record class TransactionLinkSingle : JsonModel
{
    public required TransactionLinkRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TransactionLinkRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public TransactionLinkSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionLinkSingle(TransactionLinkSingle transactionLinkSingle)
        : base(transactionLinkSingle) { }
#pragma warning restore CS8618

    public TransactionLinkSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionLinkSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionLinkSingleFromRaw.FromRawUnchecked"/>
    public static TransactionLinkSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TransactionLinkSingle(TransactionLinkRead data)
        : this()
    {
        this.Data = data;
    }
}

class TransactionLinkSingleFromRaw : IFromRawJson<TransactionLinkSingle>
{
    /// <inheritdoc/>
    public TransactionLinkSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TransactionLinkSingle.FromRawUnchecked(rawData);
}
