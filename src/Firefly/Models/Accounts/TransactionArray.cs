using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.TransactionJournals;

namespace Firefly.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<TransactionArray, TransactionArrayFromRaw>))]
public sealed record class TransactionArray : JsonModel
{
    public required IReadOnlyList<TransactionRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TransactionRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TransactionRead>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PageLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PageLink>("links");
        }
        init { this._rawData.Set("links", value); }
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
        this.Links.Validate();
        this.Meta.Validate();
    }

    public TransactionArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionArray(TransactionArray transactionArray)
        : base(transactionArray) { }
#pragma warning restore CS8618

    public TransactionArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionArrayFromRaw.FromRawUnchecked"/>
    public static TransactionArray FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionArrayFromRaw : IFromRawJson<TransactionArray>
{
    /// <inheritdoc/>
    public TransactionArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TransactionArray.FromRawUnchecked(rawData);
}
