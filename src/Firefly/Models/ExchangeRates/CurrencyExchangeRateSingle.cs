using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.ExchangeRates;

[JsonConverter(
    typeof(JsonModelConverter<CurrencyExchangeRateSingle, CurrencyExchangeRateSingleFromRaw>)
)]
public sealed record class CurrencyExchangeRateSingle : JsonModel
{
    public required CurrencyExchangeRateRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CurrencyExchangeRateRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public CurrencyExchangeRateSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyExchangeRateSingle(CurrencyExchangeRateSingle currencyExchangeRateSingle)
        : base(currencyExchangeRateSingle) { }
#pragma warning restore CS8618

    public CurrencyExchangeRateSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyExchangeRateSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencyExchangeRateSingleFromRaw.FromRawUnchecked"/>
    public static CurrencyExchangeRateSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CurrencyExchangeRateSingle(CurrencyExchangeRateRead data)
        : this()
    {
        this.Data = data;
    }
}

class CurrencyExchangeRateSingleFromRaw : IFromRawJson<CurrencyExchangeRateSingle>
{
    /// <inheritdoc/>
    public CurrencyExchangeRateSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CurrencyExchangeRateSingle.FromRawUnchecked(rawData);
}
