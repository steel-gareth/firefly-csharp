using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Models.ExchangeRates;

[JsonConverter(
    typeof(JsonModelConverter<CurrencyExchangeRateArray, CurrencyExchangeRateArrayFromRaw>)
)]
public sealed record class CurrencyExchangeRateArray : JsonModel
{
    public required IReadOnlyList<CurrencyExchangeRateRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CurrencyExchangeRateRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CurrencyExchangeRateRead>>(
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

    public CurrencyExchangeRateArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyExchangeRateArray(CurrencyExchangeRateArray currencyExchangeRateArray)
        : base(currencyExchangeRateArray) { }
#pragma warning restore CS8618

    public CurrencyExchangeRateArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyExchangeRateArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencyExchangeRateArrayFromRaw.FromRawUnchecked"/>
    public static CurrencyExchangeRateArray FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CurrencyExchangeRateArrayFromRaw : IFromRawJson<CurrencyExchangeRateArray>
{
    /// <inheritdoc/>
    public CurrencyExchangeRateArray FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CurrencyExchangeRateArray.FromRawUnchecked(rawData);
}
