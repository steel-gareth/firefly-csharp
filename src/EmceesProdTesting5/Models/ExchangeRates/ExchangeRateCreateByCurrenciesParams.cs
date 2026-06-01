using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.ExchangeRates;

/// <summary>
/// Stores a new set of exchange rates for this pair. The date is variable, and the
/// data required can be submitted as a JSON body.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExchangeRateCreateByCurrenciesParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public required string From { get; init; }

    public string? To { get; init; }

    /// <summary>
    /// The actual entries for this data set. They 'key' value is the date in YYYY-MM-DD.
    /// The value is the exchange rate.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Body
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClass<Dictionary<string, string>>(
                this.RawBodyData,
                "RawBodyData"
            );
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public string? XTraceID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-Trace-Id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-Trace-Id", value);
        }
    }

    public ExchangeRateCreateByCurrenciesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExchangeRateCreateByCurrenciesParams(
        ExchangeRateCreateByCurrenciesParams exchangeRateCreateByCurrenciesParams
    )
        : base(exchangeRateCreateByCurrenciesParams)
    {
        this.From = exchangeRateCreateByCurrenciesParams.From;
        this.To = exchangeRateCreateByCurrenciesParams.To;

        this.RawBodyData = exchangeRateCreateByCurrenciesParams.RawBodyData;
    }
#pragma warning restore CS8618

    public ExchangeRateCreateByCurrenciesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExchangeRateCreateByCurrenciesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string from,
        string to
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.From = from;
        this.To = to;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExchangeRateCreateByCurrenciesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string from,
        string to
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            from,
            to
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["From"] = JsonSerializer.SerializeToElement(this.From),
                    ["To"] = JsonSerializer.SerializeToElement(this.To),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExchangeRateCreateByCurrenciesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.From.Equals(other.From)
            && (this.To?.Equals(other.To) ?? other.To == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this.RawBodyData.Equals(other.RawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/exchange-rates/by-currencies/{0}/{1}", this.From, this.To)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        request.Headers.Add("Accept", "application/vnd.api+json");
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
