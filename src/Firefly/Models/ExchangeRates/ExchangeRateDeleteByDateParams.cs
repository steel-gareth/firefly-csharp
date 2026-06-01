using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Firefly.Core;

namespace Firefly.Models.ExchangeRates;

/// <summary>
/// Delete the currency exchange rate from 'from' to 'to' on the specified date.
/// It's important to know that the reverse exchange rate (from 'to' to 'from') will
/// not be deleted and Firefly III will still be able to infer the correct exchange
/// rate from the reverse one.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExchangeRateDeleteByDateParams : ParamsBase
{
    public required string From { get; init; }

    public required string To { get; init; }

    public string? Date { get; init; }

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

    public ExchangeRateDeleteByDateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExchangeRateDeleteByDateParams(
        ExchangeRateDeleteByDateParams exchangeRateDeleteByDateParams
    )
        : base(exchangeRateDeleteByDateParams)
    {
        this.From = exchangeRateDeleteByDateParams.From;
        this.To = exchangeRateDeleteByDateParams.To;
        this.Date = exchangeRateDeleteByDateParams.Date;
    }
#pragma warning restore CS8618

    public ExchangeRateDeleteByDateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExchangeRateDeleteByDateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string from,
        string to,
        string date
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.From = from;
        this.To = to;
        this.Date = date;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExchangeRateDeleteByDateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string from,
        string to,
        string date
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ExchangeRateDeleteByDateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.From.Equals(other.From)
            && this.To.Equals(other.To)
            && (this.Date?.Equals(other.Date) ?? other.Date == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
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
