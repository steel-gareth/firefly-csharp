using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.PiggyBanks;

namespace EmceesProdTesting5.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<PiggyBankArray, PiggyBankArrayFromRaw>))]
public sealed record class PiggyBankArray : JsonModel
{
    public required IReadOnlyList<PiggyBankRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PiggyBankRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PiggyBankRead>>(
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

    public PiggyBankArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PiggyBankArray(PiggyBankArray piggyBankArray)
        : base(piggyBankArray) { }
#pragma warning restore CS8618

    public PiggyBankArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PiggyBankArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PiggyBankArrayFromRaw.FromRawUnchecked"/>
    public static PiggyBankArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PiggyBankArrayFromRaw : IFromRawJson<PiggyBankArray>
{
    /// <inheritdoc/>
    public PiggyBankArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PiggyBankArray.FromRawUnchecked(rawData);
}
