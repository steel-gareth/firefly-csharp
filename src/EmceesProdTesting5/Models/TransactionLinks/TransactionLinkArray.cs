using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Models.TransactionLinks;

[JsonConverter(typeof(JsonModelConverter<TransactionLinkArray, TransactionLinkArrayFromRaw>))]
public sealed record class TransactionLinkArray : JsonModel
{
    public required IReadOnlyList<TransactionLinkRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TransactionLinkRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TransactionLinkRead>>(
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

    public TransactionLinkArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionLinkArray(TransactionLinkArray transactionLinkArray)
        : base(transactionLinkArray) { }
#pragma warning restore CS8618

    public TransactionLinkArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionLinkArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionLinkArrayFromRaw.FromRawUnchecked"/>
    public static TransactionLinkArray FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionLinkArrayFromRaw : IFromRawJson<TransactionLinkArray>
{
    /// <inheritdoc/>
    public TransactionLinkArray FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TransactionLinkArray.FromRawUnchecked(rawData);
}
