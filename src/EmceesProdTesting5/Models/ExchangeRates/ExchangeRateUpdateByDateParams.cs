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
/// Used to update a single currency exchange rate by its currency codes and date
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExchangeRateUpdateByDateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string From { get; init; }

    public required string To { get; init; }

    public string? Date { get; init; }

    /// <summary>
    /// The exchange rate from the base currency to the destination currency.
    /// </summary>
    public required string Rate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("rate");
        }
        init { this._rawBodyData.Set("rate", value); }
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

    public ExchangeRateUpdateByDateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExchangeRateUpdateByDateParams(
        ExchangeRateUpdateByDateParams exchangeRateUpdateByDateParams
    )
        : base(exchangeRateUpdateByDateParams)
    {
        this.From = exchangeRateUpdateByDateParams.From;
        this.To = exchangeRateUpdateByDateParams.To;
        this.Date = exchangeRateUpdateByDateParams.Date;

        this._rawBodyData = new(exchangeRateUpdateByDateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ExchangeRateUpdateByDateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExchangeRateUpdateByDateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string from,
        string to,
        string date
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.From = from;
        this.To = to;
        this.Date = date;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExchangeRateUpdateByDateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string from,
        string to,
        string date
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            from,
            to,
            date
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["From"] = JsonSerializer.SerializeToElement(this.From),
                    ["To"] = JsonSerializer.SerializeToElement(this.To),
                    ["Date"] = JsonSerializer.SerializeToElement(this.Date),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExchangeRateUpdateByDateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.From.Equals(other.From)
            && this.To.Equals(other.To)
            && (this.Date?.Equals(other.Date) ?? other.Date == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/exchange-rates/{0}/{1}/{2}", this.From, this.To, this.Date)
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
