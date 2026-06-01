using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Budgets.Limits;

/// <summary>
/// Update existing budget limit.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LimitUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string ID { get; init; }

    public string? LimitID { get; init; }

    public string? Amount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("amount", value);
        }
    }

    /// <summary>
    /// The currency code of the currency associated with this object.
    /// </summary>
    public string? CurrencyCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("currency_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("currency_code", value);
        }
    }

    /// <summary>
    /// The currency ID of the currency associated with this object.
    /// </summary>
    public string? CurrencyID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("currency_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("currency_id", value);
        }
    }

    /// <summary>
    /// The currency name of the currency associated with this object.
    /// </summary>
    public string? CurrencyName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("currency_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("currency_name", value);
        }
    }

    /// <summary>
    /// End date of the budget limit.
    /// </summary>
    public DateTimeOffset? End
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("end");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("end", value);
        }
    }

    /// <summary>
    /// Whether or not to fire the webhooks that are related to this event.
    /// </summary>
    public bool? FireWebhooks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("fire_webhooks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("fire_webhooks", value);
        }
    }

    /// <summary>
    /// Some notes for this specific budget limit.
    /// </summary>
    public string? Notes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("notes");
        }
        init { this._rawBodyData.Set("notes", value); }
    }

    /// <summary>
    /// Start date of the budget limit.
    /// </summary>
    public DateTimeOffset? Start
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("start");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("start", value);
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

    public LimitUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LimitUpdateParams(LimitUpdateParams limitUpdateParams)
        : base(limitUpdateParams)
    {
        this.ID = limitUpdateParams.ID;
        this.LimitID = limitUpdateParams.LimitID;

        this._rawBodyData = new(limitUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public LimitUpdateParams(
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
    LimitUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id,
        string limitID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
        this.LimitID = limitID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static LimitUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id,
        string limitID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id,
            limitID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["LimitID"] = JsonSerializer.SerializeToElement(this.LimitID),
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

    public virtual bool Equals(LimitUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)
            && (this.LimitID?.Equals(other.LimitID) ?? other.LimitID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/budgets/{0}/limits/{1}", this.ID, this.LimitID)
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
