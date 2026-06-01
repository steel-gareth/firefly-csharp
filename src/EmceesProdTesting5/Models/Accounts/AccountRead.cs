using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountRead, AccountReadFromRaw>))]
public sealed record class AccountRead : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required Attributes Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Attributes>("attributes");
        }
        init { this._rawData.Set("attributes", value); }
    }

    /// <summary>
    /// Immutable value
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Attributes.Validate();
        _ = this.Type;
    }

    public AccountRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountRead(AccountRead accountRead)
        : base(accountRead) { }
#pragma warning restore CS8618

    public AccountRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountReadFromRaw.FromRawUnchecked"/>
    public static AccountRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountReadFromRaw : IFromRawJson<AccountRead>
{
    /// <inheritdoc/>
    public AccountRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Can only be one one these account types. import, initial-balance and reconciliation
    /// cannot be set manually.
    /// </summary>
    public required ApiEnum<string, ShortAccountTypeProperty> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ShortAccountTypeProperty>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? AccountNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_number");
        }
        init { this._rawData.Set("account_number", value); }
    }

    /// <summary>
    /// Is only mandatory when the type is asset.
    /// </summary>
    public ApiEnum<string, AccountRoleProperty>? AccountRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AccountRoleProperty>>(
                "account_role"
            );
        }
        init { this._rawData.Set("account_role", value); }
    }

    public bool? Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// If you submit a start AND end date, this will be the difference between those
    /// two moments.
    /// </summary>
    public string? BalanceDifference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("balance_difference");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("balance_difference", value);
        }
    }

    public string? Bic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bic");
        }
        init { this._rawData.Set("bic", value); }
    }

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
    /// Mandatory when the account_role is ccAsset. Can only be monthlyFull or null.
    /// </summary>
    public ApiEnum<string, CreditCardTypeProperty>? CreditCardType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CreditCardTypeProperty>>(
                "credit_card_type"
            );
        }
        init { this._rawData.Set("credit_card_type", value); }
    }

    /// <summary>
    /// The currency code of the currency associated with this object.
    /// </summary>
    public string? CurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_code", value);
        }
    }

    public int? CurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("currency_decimal_places");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_decimal_places", value);
        }
    }

    /// <summary>
    /// The currency ID of the currency associated with this object.
    /// </summary>
    public string? CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_id", value);
        }
    }

    /// <summary>
    /// The currency name of the currency associated with this object.
    /// </summary>
    public string? CurrencyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_name", value);
        }
    }

    public string? CurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_symbol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_symbol", value);
        }
    }

    /// <summary>
    /// The current balance of the account in the account's currency. If the account
    /// has no currency, this is the balance in the administration's primary currency.
    /// Either way, the `currency_*` fields reflect the currency used.
    /// </summary>
    public string? CurrentBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("current_balance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("current_balance", value);
        }
    }

    /// <summary>
    /// The timestamp for this date is always 23:59:59, to indicate it's the balance
    /// at the very END of that particular day.
    /// </summary>
    public DateTimeOffset? CurrentBalanceDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("current_balance_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("current_balance_date", value);
        }
    }

    /// <summary>
    /// In liability accounts (loans, debts and mortgages), this is the amount of
    /// debt in the account's currency (see the `currency_*` fields). In asset accounts,
    /// this is NULL.
    /// </summary>
    public string? DebtAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("debt_amount");
        }
        init { this._rawData.Set("debt_amount", value); }
    }

    public string? Iban
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("iban");
        }
        init { this._rawData.Set("iban", value); }
    }

    public bool? IncludeNetWorth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("include_net_worth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("include_net_worth", value);
        }
    }

    /// <summary>
    /// Mandatory when type is liability. Interest percentage.
    /// </summary>
    public string? Interest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("interest");
        }
        init { this._rawData.Set("interest", value); }
    }

    /// <summary>
    /// Mandatory when type is liability. Period over which the interest is calculated.
    /// </summary>
    public ApiEnum<string, InterestPeriodProperty>? InterestPeriod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InterestPeriodProperty>>(
                "interest_period"
            );
        }
        init { this._rawData.Set("interest_period", value); }
    }

    /// <summary>
    /// Last activity of the account.
    /// </summary>
    public DateTimeOffset? LastActivity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_activity");
        }
        init { this._rawData.Set("last_activity", value); }
    }

    /// <summary>
    /// Latitude of the accounts's location, if applicable. Can be used to draw a map.
    /// </summary>
    public double? Latitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("latitude");
        }
        init { this._rawData.Set("latitude", value); }
    }

    /// <summary>
    /// 'credit' indicates somebody owes you the liability. 'debit' Indicates you
    /// owe this debt yourself. Works only for liabilities.
    /// </summary>
    public ApiEnum<string, LiabilityDirectionProperty>? LiabilityDirection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LiabilityDirectionProperty>>(
                "liability_direction"
            );
        }
        init { this._rawData.Set("liability_direction", value); }
    }

    /// <summary>
    /// Mandatory when type is liability. Specifies the exact type.
    /// </summary>
    public ApiEnum<string, LiabilityTypeProperty>? LiabilityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LiabilityTypeProperty>>(
                "liability_type"
            );
        }
        init { this._rawData.Set("liability_type", value); }
    }

    /// <summary>
    /// Latitude of the accounts's location, if applicable. Can be used to draw a map.
    /// </summary>
    public double? Longitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("longitude");
        }
        init { this._rawData.Set("longitude", value); }
    }

    /// <summary>
    /// Mandatory when the account_role is ccAsset. Moment at which CC payment installments
    /// are asked for by the bank.
    /// </summary>
    public DateTimeOffset? MonthlyPaymentDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("monthly_payment_date");
        }
        init { this._rawData.Set("monthly_payment_date", value); }
    }

    public string? Notes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("notes");
        }
        init { this._rawData.Set("notes", value); }
    }

    /// <summary>
    /// The group ID of the group this object is part of. NULL if no group.
    /// </summary>
    public string? ObjectGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("object_group_id");
        }
        init { this._rawData.Set("object_group_id", value); }
    }

    /// <summary>
    /// The order of the group. At least 1, for the highest sorting.
    /// </summary>
    public int? ObjectGroupOrder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("object_group_order");
        }
        init { this._rawData.Set("object_group_order", value); }
    }

    /// <summary>
    /// The name of the group. NULL if no group.
    /// </summary>
    public string? ObjectGroupTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("object_group_title");
        }
        init { this._rawData.Set("object_group_title", value); }
    }

    /// <summary>
    /// Indicates whether the account has a currency setting. If false, the account
    /// uses the administration's primary currency. Asset accounts and liability accounts
    /// always have a currency setting, while expense and revenue accounts do not.
    /// </summary>
    public bool? ObjectHasCurrencySetting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("object_has_currency_setting");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("object_has_currency_setting", value);
        }
    }

    /// <summary>
    /// Represents the opening balance, the initial amount this account holds in the
    /// currency of the account or the administration's primary currency if the account
    /// has no currency. Either way, the `currency_*` fields reflect the currency used.
    /// </summary>
    public string? OpeningBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("opening_balance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("opening_balance", value);
        }
    }

    /// <summary>
    /// Represents the date of the opening balance.
    /// </summary>
    public DateTimeOffset? OpeningBalanceDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("opening_balance_date");
        }
        init { this._rawData.Set("opening_balance_date", value); }
    }

    /// <summary>
    /// Order of the account. Is NULL if account is not asset or liability.
    /// </summary>
    public int? Order
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("order");
        }
        init { this._rawData.Set("order", value); }
    }

    /// <summary>
    /// If you submit a start AND end date, this will be the difference in the currency
    /// of the account or the administration's primary currency between those two moments.
    /// </summary>
    public string? PcBalanceDifference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_balance_difference");
        }
        init { this._rawData.Set("pc_balance_difference", value); }
    }

    /// <summary>
    /// The current balance of the account in the administration's primary currency.
    /// The `primary_currency_*` fields reflect the currency used. This field is NULL
    /// if the user does have 'convert to primary' set to true in their settings.
    /// </summary>
    public string? PcCurrentBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_current_balance");
        }
        init { this._rawData.Set("pc_current_balance", value); }
    }

    /// <summary>
    /// In liability accounts (loans, debts and mortgages), this is the amount of
    /// debt in the administration's primary currency (see the `currency_*` fields.
    /// In asset accounts, this is NULL.
    /// </summary>
    public string? PcDebtAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_debt_amount");
        }
        init { this._rawData.Set("pc_debt_amount", value); }
    }

    /// <summary>
    /// The opening balance of the account in the administration's primary currency
    /// (pc). The `primary_currency_*` fields reflect the currency used. This field
    /// is NULL if the user does have 'convert to primary' set to true in their settings.
    /// </summary>
    public string? PcOpeningBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_opening_balance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pc_opening_balance", value);
        }
    }

    /// <summary>
    /// The virtual balance of the account in the administration's primary currency
    /// (pc). The `primary_currency_*` fields reflect the currency used. This field
    /// is NULL if the user does have 'convert to primary' set to true in their settings.
    /// </summary>
    public string? PcVirtualBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_virtual_balance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pc_virtual_balance", value);
        }
    }

    /// <summary>
    /// The currency code of the administration's primary currency.
    /// </summary>
    public string? PrimaryCurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_currency_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_currency_code", value);
        }
    }

    /// <summary>
    /// The currency decimal places of the administration's primary currency.
    /// </summary>
    public int? PrimaryCurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("primary_currency_decimal_places");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_currency_decimal_places", value);
        }
    }

    /// <summary>
    /// The currency ID of the administration's primary currency.
    /// </summary>
    public string? PrimaryCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_currency_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_currency_id", value);
        }
    }

    /// <summary>
    /// The currency name of the administration's primary currency.
    /// </summary>
    public string? PrimaryCurrencyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_currency_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_currency_name", value);
        }
    }

    /// <summary>
    /// The currency symbol of the administration's primary currency.
    /// </summary>
    public string? PrimaryCurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_currency_symbol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primary_currency_symbol", value);
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

    /// <summary>
    /// The virtual balance of the account in the account's currency or the administration's
    /// primary currency if the account has no currency.
    /// </summary>
    public string? VirtualBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("virtual_balance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("virtual_balance", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("zoom_level");
        }
        init { this._rawData.Set("zoom_level", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Type.Validate();
        _ = this.AccountNumber;
        this.AccountRole?.Validate();
        _ = this.Active;
        _ = this.BalanceDifference;
        _ = this.Bic;
        _ = this.CreatedAt;
        this.CreditCardType?.Validate();
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencyName;
        _ = this.CurrencySymbol;
        _ = this.CurrentBalance;
        _ = this.CurrentBalanceDate;
        _ = this.DebtAmount;
        _ = this.Iban;
        _ = this.IncludeNetWorth;
        _ = this.Interest;
        this.InterestPeriod?.Validate();
        _ = this.LastActivity;
        _ = this.Latitude;
        this.LiabilityDirection?.Validate();
        this.LiabilityType?.Validate();
        _ = this.Longitude;
        _ = this.MonthlyPaymentDate;
        _ = this.Notes;
        _ = this.ObjectGroupID;
        _ = this.ObjectGroupOrder;
        _ = this.ObjectGroupTitle;
        _ = this.ObjectHasCurrencySetting;
        _ = this.OpeningBalance;
        _ = this.OpeningBalanceDate;
        _ = this.Order;
        _ = this.PcBalanceDifference;
        _ = this.PcCurrentBalance;
        _ = this.PcDebtAmount;
        _ = this.PcOpeningBalance;
        _ = this.PcVirtualBalance;
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencyName;
        _ = this.PrimaryCurrencySymbol;
        _ = this.UpdatedAt;
        _ = this.VirtualBalance;
        _ = this.ZoomLevel;
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
