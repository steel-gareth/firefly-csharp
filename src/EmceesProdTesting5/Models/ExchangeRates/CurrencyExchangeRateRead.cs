using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using Attachments = EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Models.ExchangeRates;

[JsonConverter(
    typeof(JsonModelConverter<CurrencyExchangeRateRead, CurrencyExchangeRateReadFromRaw>)
)]
public sealed record class CurrencyExchangeRateRead : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public Attributes? Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Attributes>("attributes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("attributes", value);
        }
    }

    public Attachments::ObjectLink? Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Attachments::ObjectLink>("links");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("links", value);
        }
    }

    /// <summary>
    /// Immutable value
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Attributes?.Validate();
        this.Links?.Validate();
        _ = this.Type;
    }

    public CurrencyExchangeRateRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyExchangeRateRead(CurrencyExchangeRateRead currencyExchangeRateRead)
        : base(currencyExchangeRateRead) { }
#pragma warning restore CS8618

    public CurrencyExchangeRateRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyExchangeRateRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencyExchangeRateReadFromRaw.FromRawUnchecked"/>
    public static CurrencyExchangeRateRead FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CurrencyExchangeRateReadFromRaw : IFromRawJson<CurrencyExchangeRateRead>
{
    /// <inheritdoc/>
    public CurrencyExchangeRateRead FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CurrencyExchangeRateRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Date and time of the exchange rate.
    /// </summary>
    public DateTimeOffset? Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("date", value);
        }
    }

    /// <summary>
    /// Base currency code for this exchange rate entry.
    /// </summary>
    public string? FromCurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from_currency_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from_currency_code", value);
        }
    }

    /// <summary>
    /// Base currency decimal places for this exchange rate entry.
    /// </summary>
    public int? FromCurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("from_currency_decimal_places");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from_currency_decimal_places", value);
        }
    }

    /// <summary>
    /// Base currency ID for this exchange rate entry.
    /// </summary>
    public string? FromCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from_currency_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from_currency_id", value);
        }
    }

    /// <summary>
    /// Base currency name for this exchange rate entry.
    /// </summary>
    public string? FromCurrencyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from_currency_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from_currency_name", value);
        }
    }

    /// <summary>
    /// Base currency symbol for this exchange rate entry.
    /// </summary>
    public string? FromCurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from_currency_symbol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from_currency_symbol", value);
        }
    }

    /// <summary>
    /// The actual exchange rate. How many 'to' currency will you get for 1 'from' currency?
    /// </summary>
    public string? Rate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    /// <summary>
    /// Destination currency code for this exchange rate entry.
    /// </summary>
    public string? ToCurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("to_currency_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("to_currency_code", value);
        }
    }

    /// <summary>
    /// Destination currency decimal places for this exchange rate entry.
    /// </summary>
    public int? ToCurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("to_currency_decimal_places");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("to_currency_decimal_places", value);
        }
    }

    /// <summary>
    /// Destination currency ID for this exchange rate entry.
    /// </summary>
    public string? ToCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("to_currency_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("to_currency_id", value);
        }
    }

    /// <summary>
    /// Destination currency name for this exchange rate entry.
    /// </summary>
    public string? ToCurrencyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("to_currency_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("to_currency_name", value);
        }
    }

    /// <summary>
    /// Destination currency symbol for this exchange rate entry.
    /// </summary>
    public string? ToCurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("to_currency_symbol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("to_currency_symbol", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Date;
        _ = this.FromCurrencyCode;
        _ = this.FromCurrencyDecimalPlaces;
        _ = this.FromCurrencyID;
        _ = this.FromCurrencyName;
        _ = this.FromCurrencySymbol;
        _ = this.Rate;
        _ = this.ToCurrencyCode;
        _ = this.ToCurrencyDecimalPlaces;
        _ = this.ToCurrencyID;
        _ = this.ToCurrencyName;
        _ = this.ToCurrencySymbol;
        _ = this.UpdatedAt;
    }

    public Attributes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attributes(Attributes attributes)
        : base(attributes) { }
#pragma warning restore CS8618

    public Attributes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Attributes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttributesFromRaw.FromRawUnchecked"/>
    public static Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttributesFromRaw : IFromRawJson<Attributes>
{
    /// <inheritdoc/>
    public Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attributes.FromRawUnchecked(rawData);
}
