using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.ExchangeRates;

/// <summary>
/// Deletes ALL currency exchange rates from 'from' to 'to'. It's important to know
/// that the reverse exchange rates (from 'to' to 'from') will not be deleted and
/// Firefly III will still be able to infer the correct exchange rate from the reverse one.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExchangeRateDeleteAllByCurrenciesParams : ParamsBase
{
    public required string From { get; init; }

    public string? To { get; init; }

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

    public ExchangeRateDeleteAllByCurrenciesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExchangeRateDeleteAllByCurrenciesParams(
        ExchangeRateDeleteAllByCurrenciesParams exchangeRateDeleteAllByCurrenciesParams
    )
        : base(exchangeRateDeleteAllByCurrenciesParams)
    {
        this.From = exchangeRateDeleteAllByCurrenciesParams.From;
        this.To = exchangeRateDeleteAllByCurrenciesParams.To;
    }
#pragma warning restore CS8618

    public ExchangeRateDeleteAllByCurrenciesParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExchangeRateDeleteAllByCurrenciesParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string from,
        string to
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.From = from;
        this.To = to;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExchangeRateDeleteAllByCurrenciesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string from,
        string to
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExchangeRateDeleteAllByCurrenciesParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.From.Equals(other.From)
            && (this.To?.Equals(other.To) ?? other.To == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/exchange-rates/{0}/{1}", this.From, this.To)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
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
