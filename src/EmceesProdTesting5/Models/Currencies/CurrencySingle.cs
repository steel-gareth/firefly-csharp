using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Currencies;

[JsonConverter(typeof(JsonModelConverter<CurrencySingle, CurrencySingleFromRaw>))]
public sealed record class CurrencySingle : JsonModel
{
    public required CurrencyRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CurrencyRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public CurrencySingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencySingle(CurrencySingle currencySingle)
        : base(currencySingle) { }
#pragma warning restore CS8618

    public CurrencySingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencySingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencySingleFromRaw.FromRawUnchecked"/>
    public static CurrencySingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CurrencySingle(CurrencyRead data)
        : this()
    {
        this.Data = data;
    }
}

class CurrencySingleFromRaw : IFromRawJson<CurrencySingle>
{
    /// <inheritdoc/>
    public CurrencySingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CurrencySingle.FromRawUnchecked(rawData);
}
