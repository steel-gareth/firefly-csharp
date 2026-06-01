using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Currencies;

/// <summary>
/// Update existing currency.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CurrencyUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? Code { get; init; }

    /// <summary>
    /// The currency code
    /// </summary>
    public string? CodeValue
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("code", value);
        }
    }

    /// <summary>
    /// How many decimals to use when displaying this currency. Between 0 and 16.
    /// </summary>
    public int? DecimalPlaces
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("decimal_places");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("decimal_places", value);
        }
    }

    /// <summary>
    /// If the currency is enabled
    /// </summary>
    public bool? Enabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("enabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("enabled", value);
        }
    }

    /// <summary>
    /// The currency name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// If the currency must be the primary for the user. You can only submit TRUE.
    /// Submitting FALSE will not drop this currency as the primary currency, because
    /// then the system would be without one.
    /// </summary>
    public ApiEnum<bool, CurrencyUpdateParamsPrimary>? Primary
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<bool, CurrencyUpdateParamsPrimary>>(
                "primary"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("primary", value);
        }
    }

    /// <summary>
    /// The currency symbol
    /// </summary>
    public string? Symbol
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("symbol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("symbol", value);
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

    public CurrencyUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyUpdateParams(CurrencyUpdateParams currencyUpdateParams)
        : base(currencyUpdateParams)
    {
        this.Code = currencyUpdateParams.Code;

        this._rawBodyData = new(currencyUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CurrencyUpdateParams(
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
    CurrencyUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string code
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.Code = code;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CurrencyUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string code
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            code
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["Code"] = JsonSerializer.SerializeToElement(this.Code),
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

    public virtual bool Equals(CurrencyUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Code?.Equals(other.Code) ?? other.Code == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/currencies/{0}", this.Code)
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
/// If the currency must be the primary for the user. You can only submit TRUE. Submitting
/// FALSE will not drop this currency as the primary currency, because then the system
/// would be without one.
/// </summary>
[JsonConverter(typeof(CurrencyUpdateParamsPrimaryConverter))]
public enum CurrencyUpdateParamsPrimary
{
    True,
}

sealed class CurrencyUpdateParamsPrimaryConverter : JsonConverter<CurrencyUpdateParamsPrimary>
{
    public override CurrencyUpdateParamsPrimary Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => CurrencyUpdateParamsPrimary.True,
            _ => (CurrencyUpdateParamsPrimary)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CurrencyUpdateParamsPrimary value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CurrencyUpdateParamsPrimary.True => true,
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
