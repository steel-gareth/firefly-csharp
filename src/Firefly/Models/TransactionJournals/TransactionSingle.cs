using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.TransactionJournals;

[JsonConverter(typeof(JsonModelConverter<TransactionSingle, TransactionSingleFromRaw>))]
public sealed record class TransactionSingle : JsonModel
{
    public required TransactionRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TransactionRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public TransactionSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionSingle(TransactionSingle transactionSingle)
        : base(transactionSingle) { }
#pragma warning restore CS8618

    public TransactionSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionSingleFromRaw.FromRawUnchecked"/>
    public static TransactionSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TransactionSingle(TransactionRead data)
        : this()
    {
        this.Data = data;
    }
}

class TransactionSingleFromRaw : IFromRawJson<TransactionSingle>
{
    /// <inheritdoc/>
    public TransactionSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TransactionSingle.FromRawUnchecked(rawData);
}
