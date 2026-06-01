using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Chart.Balance;

/// <summary>
/// This endpoint returns the data required to generate a chart with balance information.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BalanceRetrieveBalanceParams : ParamsBase
{
    /// <summary>
    /// A date formatted YYYY-MM-DD.
    /// </summary>
    public required string End
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("end");
        }
        init { this._rawQueryData.Set("end", value); }
    }

    /// <summary>
    /// A date formatted YYYY-MM-DD.
    /// </summary>
    public required string Start
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("start");
        }
        init { this._rawQueryData.Set("start", value); }
    }

    /// <summary>
    /// Limit the chart to these asset accounts or liabilities. Only asset accounts
    /// and liabilities will be accepted. Other types will be silently dropped.
    ///
    /// <para>This list of accounts will be OVERRULED by the `preselected` parameter.</para>
    /// </summary>
    public IReadOnlyList<long>? Accounts
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<long>>("accounts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<long>?>(
                "accounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional period to group the data by. If not provided, it will default to
    /// '1M' or whatever is deemed relevant for the range provided.
    ///
    /// <para>If you want to know which periods are available, see the enums or get
    /// the configuration value: `GET /api/v1/configuration/firefly.valid_view_ranges`</para>
    /// </summary>
    public ApiEnum<string, Period>? Period
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Period>>("period");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("period", value);
        }
    }

    /// <summary>
    /// Optional set of preselected accounts to limit the chart to. This may be easier
    /// than submitting all asset accounts manually, for example. If you want to
    /// know which selection are available, see the enums here or get the configuration
    /// value: `GET /api/v1/configuration/firefly.preselected_accounts`
    ///
    /// <para>- `empty`: do not do a pre-selection - `all`: select all asset and all
    /// liability accounts - `assets`: select all asset accounts - `liabilities`:
    /// select all liability accounts</para>
    ///
    /// <para>If no accounts are found, the user's "frontpage accounts" preference
    /// will be used. If that is empty, all asset accounts will be used.</para>
    /// </summary>
    public ApiEnum<string, Preselected>? Preselected
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Preselected>>("preselected");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("preselected", value);
        }
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

    public BalanceRetrieveBalanceParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceRetrieveBalanceParams(BalanceRetrieveBalanceParams balanceRetrieveBalanceParams)
        : base(balanceRetrieveBalanceParams) { }
#pragma warning restore CS8618

    public BalanceRetrieveBalanceParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceRetrieveBalanceParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BalanceRetrieveBalanceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(BalanceRetrieveBalanceParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/chart/balance/balance")
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

/// <summary>
/// Optional period to group the data by. If not provided, it will default to '1M'
/// or whatever is deemed relevant for the range provided.
///
/// <para>If you want to know which periods are available, see the enums or get the
/// configuration value: `GET /api/v1/configuration/firefly.valid_view_ranges`</para>
/// </summary>
[JsonConverter(typeof(PeriodConverter))]
public enum Period
{
    V1D,
    V1W,
    V1M,
    V3M,
    V6M,
    V1Y,
}

sealed class PeriodConverter : JsonConverter<Period>
{
    public override Period Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1D" => Period.V1D,
            "1W" => Period.V1W,
            "1M" => Period.V1M,
            "3M" => Period.V3M,
            "6M" => Period.V6M,
            "1Y" => Period.V1Y,
            _ => (Period)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Period value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Period.V1D => "1D",
                Period.V1W => "1W",
                Period.V1M => "1M",
                Period.V3M => "3M",
                Period.V6M => "6M",
                Period.V1Y => "1Y",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Optional set of preselected accounts to limit the chart to. This may be easier
/// than submitting all asset accounts manually, for example. If you want to know
/// which selection are available, see the enums here or get the configuration value:
/// `GET /api/v1/configuration/firefly.preselected_accounts`
///
/// <para>- `empty`: do not do a pre-selection - `all`: select all asset and all
/// liability accounts - `assets`: select all asset accounts - `liabilities`: select
/// all liability accounts</para>
///
/// <para>If no accounts are found, the user's "frontpage accounts" preference will
/// be used. If that is empty, all asset accounts will be used.</para>
/// </summary>
[JsonConverter(typeof(PreselectedConverter))]
public enum Preselected
{
    Empty,
    All,
    Assets,
    Liabilities,
}

sealed class PreselectedConverter : JsonConverter<Preselected>
{
    public override Preselected Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "empty" => Preselected.Empty,
            "all" => Preselected.All,
            "assets" => Preselected.Assets,
            "liabilities" => Preselected.Liabilities,
            _ => (Preselected)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Preselected value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Preselected.Empty => "empty",
                Preselected.All => "all",
                Preselected.Assets => "assets",
                Preselected.Liabilities => "liabilities",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
