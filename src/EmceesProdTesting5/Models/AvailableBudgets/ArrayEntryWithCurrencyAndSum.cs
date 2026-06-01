using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.AvailableBudgets;

[JsonConverter(
    typeof(JsonModelConverter<ArrayEntryWithCurrencyAndSum, ArrayEntryWithCurrencyAndSumFromRaw>)
)]
public sealed record class ArrayEntryWithCurrencyAndSum : JsonModel
{
    public string? CurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_code", value);
        }
    }

    /// <summary>
    /// Number of decimals supported by the currency
    /// </summary>
    public int? CurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("currency_decimal_places");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_decimal_places", value);
        }
    }

    public string? CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_id", value);
        }
    }

    public string? CurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_symbol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_symbol", value);
        }
    }

    /// <summary>
    /// The amount earned, spent or transferred.
    /// </summary>
    public string? Sum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sum");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sum", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencySymbol;
        _ = this.Sum;
    }

    public ArrayEntryWithCurrencyAndSum() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArrayEntryWithCurrencyAndSum(ArrayEntryWithCurrencyAndSum arrayEntryWithCurrencyAndSum)
        : base(arrayEntryWithCurrencyAndSum) { }
#pragma warning restore CS8618

    public ArrayEntryWithCurrencyAndSum(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArrayEntryWithCurrencyAndSum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArrayEntryWithCurrencyAndSumFromRaw.FromRawUnchecked"/>
    public static ArrayEntryWithCurrencyAndSum FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ArrayEntryWithCurrencyAndSumFromRaw : IFromRawJson<ArrayEntryWithCurrencyAndSum>
{
    /// <inheritdoc/>
    public ArrayEntryWithCurrencyAndSum FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ArrayEntryWithCurrencyAndSum.FromRawUnchecked(rawData);
}
