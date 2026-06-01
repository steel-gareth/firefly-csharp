using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Bills;

/// <summary>
/// Creates a new bill. The data required can be submitted as a JSON body or as a
/// list of parameters.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BillCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string AmountMax
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("amount_max");
        }
        init { this._rawBodyData.Set("amount_max", value); }
    }

    public required string AmountMin
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("amount_min");
        }
        init { this._rawBodyData.Set("amount_min", value); }
    }

    public required DateTimeOffset Date
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<DateTimeOffset>("date");
        }
        init { this._rawBodyData.Set("date", value); }
    }

    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// How often the bill must be paid.
    /// </summary>
    public required ApiEnum<string, BillRepeatFrequency> RepeatFreq
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, BillRepeatFrequency>>(
                "repeat_freq"
            );
        }
        init { this._rawBodyData.Set("repeat_freq", value); }
    }

    /// <summary>
    /// If the bill is active.
    /// </summary>
    public bool? Active
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("active", value);
        }
    }

    /// <summary>
    /// Use either currency_id or currency_code
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
    /// Use either currency_id or currency_code
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
    /// The date after which this bill is no longer valid or applicable
    /// </summary>
    public DateTimeOffset? EndDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("end_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("end_date", value);
        }
    }

    /// <summary>
    /// The date before which the bill must be renewed (or cancelled)
    /// </summary>
    public DateTimeOffset? ExtensionDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("extension_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("extension_date", value);
        }
    }

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
    /// The group ID of the group this object is part of. NULL if no group.
    /// </summary>
    public string? ObjectGroupID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("object_group_id");
        }
        init { this._rawBodyData.Set("object_group_id", value); }
    }

    /// <summary>
    /// The name of the group. NULL if no group.
    /// </summary>
    public string? ObjectGroupTitle
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("object_group_title");
        }
        init { this._rawBodyData.Set("object_group_title", value); }
    }

    /// <summary>
    /// How often the bill must be skipped. 1 means a bi-monthly bill.
    /// </summary>
    public int? Skip
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("skip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("skip", value);
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

    public BillCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillCreateParams(BillCreateParams billCreateParams)
        : base(billCreateParams)
    {
        this._rawBodyData = new(billCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BillCreateParams(
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
    BillCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BillCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(BillCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/bills")
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
