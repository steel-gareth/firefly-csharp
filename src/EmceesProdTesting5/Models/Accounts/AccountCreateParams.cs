using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Accounts;

/// <summary>
/// Creates a new account. The data required can be submitted as a JSON body or as
/// a list of parameters (in key=value pairs, like a webform).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AccountCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
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
    /// Can only be one one these account types. import, initial-balance and reconciliation
    /// cannot be set manually.
    /// </summary>
    public required ApiEnum<string, ShortAccountTypeProperty> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ShortAccountTypeProperty>>(
                "type"
            );
        }
        init { this._rawBodyData.Set("type", value); }
    }

    public string? AccountNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("account_number");
        }
        init { this._rawBodyData.Set("account_number", value); }
    }

    /// <summary>
    /// Is only mandatory when the type is asset.
    /// </summary>
    public ApiEnum<string, AccountRoleProperty>? AccountRole
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AccountRoleProperty>>(
                "account_role"
            );
        }
        init { this._rawBodyData.Set("account_role", value); }
    }

    /// <summary>
    /// If omitted, defaults to true.
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

    public string? Bic
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("bic");
        }
        init { this._rawBodyData.Set("bic", value); }
    }

    /// <summary>
    /// Mandatory when the account_role is ccAsset. Can only be monthlyFull or null.
    /// </summary>
    public ApiEnum<string, CreditCardTypeProperty>? CreditCardType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CreditCardTypeProperty>>(
                "credit_card_type"
            );
        }
        init { this._rawBodyData.Set("credit_card_type", value); }
    }

    /// <summary>
    /// Use either currency_id or currency_code. Defaults to the user's financial
    /// administration's currency.
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
    /// Use either currency_id or currency_code. Defaults to the user's financial
    /// administration's currency.
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

    public string? Iban
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("iban");
        }
        init { this._rawBodyData.Set("iban", value); }
    }

    /// <summary>
    /// If omitted, defaults to true.
    /// </summary>
    public bool? IncludeNetWorth
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("include_net_worth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("include_net_worth", value);
        }
    }

    /// <summary>
    /// Mandatory when type is liability. Interest percentage.
    /// </summary>
    public string? Interest
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("interest");
        }
        init { this._rawBodyData.Set("interest", value); }
    }

    /// <summary>
    /// Mandatory when type is liability. Period over which the interest is calculated.
    /// </summary>
    public ApiEnum<string, InterestPeriodProperty>? InterestPeriod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, InterestPeriodProperty>>(
                "interest_period"
            );
        }
        init { this._rawBodyData.Set("interest_period", value); }
    }

    /// <summary>
    /// Latitude of the accounts's location, if applicable. Can be used to draw a map.
    /// </summary>
    public double? Latitude
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("latitude");
        }
        init { this._rawBodyData.Set("latitude", value); }
    }

    /// <summary>
    /// 'credit' indicates somebody owes you the liability. 'debit' Indicates you
    /// owe this debt yourself. Works only for liabilities.
    /// </summary>
    public ApiEnum<string, LiabilityDirectionProperty>? LiabilityDirection
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, LiabilityDirectionProperty>>(
                "liability_direction"
            );
        }
        init { this._rawBodyData.Set("liability_direction", value); }
    }

    /// <summary>
    /// Mandatory when type is liability. Specifies the exact type.
    /// </summary>
    public ApiEnum<string, LiabilityTypeProperty>? LiabilityType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, LiabilityTypeProperty>>(
                "liability_type"
            );
        }
        init { this._rawBodyData.Set("liability_type", value); }
    }

    /// <summary>
    /// Latitude of the accounts's location, if applicable. Can be used to draw a map.
    /// </summary>
    public double? Longitude
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("longitude");
        }
        init { this._rawBodyData.Set("longitude", value); }
    }

    /// <summary>
    /// Mandatory when the account_role is ccAsset. Moment at which CC payment installments
    /// are asked for by the bank.
    /// </summary>
    public DateTimeOffset? MonthlyPaymentDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("monthly_payment_date");
        }
        init { this._rawBodyData.Set("monthly_payment_date", value); }
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
    /// Represents the opening balance, the initial amount this account holds.
    /// </summary>
    public string? OpeningBalance
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("opening_balance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("opening_balance", value);
        }
    }

    /// <summary>
    /// Represents the date of the opening balance.
    /// </summary>
    public DateTimeOffset? OpeningBalanceDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("opening_balance_date");
        }
        init { this._rawBodyData.Set("opening_balance_date", value); }
    }

    /// <summary>
    /// Order of the account
    /// </summary>
    public int? Order
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("order");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("order", value);
        }
    }

    public string? VirtualBalance
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("virtual_balance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("virtual_balance", value);
        }
    }

    /// <summary>
    /// Zoom level for the map, if drawn. This to set the box right. Unfortunately
    /// this is a proprietary value because each map provider has different zoom levels.
    /// </summary>
    public int? ZoomLevel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("zoom_level");
        }
        init { this._rawBodyData.Set("zoom_level", value); }
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

    public AccountCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountCreateParams(AccountCreateParams accountCreateParams)
        : base(accountCreateParams)
    {
        this._rawBodyData = new(accountCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AccountCreateParams(
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
    AccountCreateParams(
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
    public static AccountCreateParams FromRawUnchecked(
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

    public virtual bool Equals(AccountCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/accounts")
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
