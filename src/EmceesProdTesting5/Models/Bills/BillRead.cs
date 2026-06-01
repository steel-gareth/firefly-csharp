using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Bills;

[JsonConverter(typeof(JsonModelConverter<BillRead, BillReadFromRaw>))]
public sealed record class BillRead : JsonModel
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

    public BillRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillRead(BillRead billRead)
        : base(billRead) { }
#pragma warning restore CS8618

    public BillRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillReadFromRaw.FromRawUnchecked"/>
    public static BillRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillReadFromRaw : IFromRawJson<BillRead>
{
    /// <inheritdoc/>
    public BillRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    /// <summary>
    /// If the subscription is active.
    /// </summary>
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
    /// The average amount that is expected for this subscription in the subscription's currency.
    /// </summary>
    public string? AmountAvg
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("amount_avg");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("amount_avg", value);
        }
    }

    /// <summary>
    /// The maximum amount that is expected for this subscription in the subscription's currency.
    /// </summary>
    public string? AmountMax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("amount_max");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("amount_max", value);
        }
    }

    /// <summary>
    /// The minimum amount that is expected for this subscription in the subscription's currency.
    /// </summary>
    public string? AmountMin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("amount_min");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("amount_min", value);
        }
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

    public DateTimeOffset? Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("date", value);
        }
    }

    /// <summary>
    /// The date after which this subscription is no longer valid or applicable
    /// </summary>
    public DateTimeOffset? EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("end_date");
        }
        init { this._rawData.Set("end_date", value); }
    }

    /// <summary>
    /// The date before which the subscription must be renewed (or cancelled)
    /// </summary>
    public DateTimeOffset? ExtensionDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("extension_date");
        }
        init { this._rawData.Set("extension_date", value); }
    }

    /// <summary>
    /// The name of the subscription.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// When the subscription is expected to be due.
    /// </summary>
    public DateTimeOffset? NextExpectedMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("next_expected_match");
        }
        init { this._rawData.Set("next_expected_match", value); }
    }

    /// <summary>
    /// Formatted (locally) when the subscription is due.
    /// </summary>
    public string? NextExpectedMatchDiff
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_expected_match_diff");
        }
        init { this._rawData.Set("next_expected_match_diff", value); }
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
    /// Indicates whether the object has a currency setting. If false, the object
    /// uses the administration's primary currency.
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
    /// Order of the subscription.
    /// </summary>
    public int? Order
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("order");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("order", value);
        }
    }

    /// <summary>
    /// Array of past transactions when the subscription was paid.
    /// </summary>
    public IReadOnlyList<PaidDate>? PaidDates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PaidDate>>("paid_dates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PaidDate>?>(
                "paid_dates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of future dates when the bill is expected to be paid. Autogenerated.
    /// </summary>
    public IReadOnlyList<DateTimeOffset>? PayDates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DateTimeOffset>>("pay_dates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DateTimeOffset>?>(
                "pay_dates",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The average amount that is expected for this subscription in the administration's
    /// primary currency.
    /// </summary>
    public string? PcAmountAvg
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_amount_avg");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pc_amount_avg", value);
        }
    }

    /// <summary>
    /// The maximum amount that is expected for this subscription in the administration's
    /// primary currency.
    /// </summary>
    public string? PcAmountMax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_amount_max");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pc_amount_max", value);
        }
    }

    /// <summary>
    /// The minimum amount that is expected for this subscription in the administration's
    /// primary currency.
    /// </summary>
    public string? PcAmountMin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_amount_min");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pc_amount_min", value);
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

    /// <summary>
    /// How often the bill must be paid.
    /// </summary>
    public ApiEnum<string, BillRepeatFrequency>? RepeatFreq
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BillRepeatFrequency>>(
                "repeat_freq"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("repeat_freq", value);
        }
    }

    /// <summary>
    /// How often the subscription will be skipped. 1 means a bi-monthly subscription.
    /// </summary>
    public int? Skip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("skip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("skip", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        _ = this.AmountAvg;
        _ = this.AmountMax;
        _ = this.AmountMin;
        _ = this.CreatedAt;
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencyName;
        _ = this.CurrencySymbol;
        _ = this.Date;
        _ = this.EndDate;
        _ = this.ExtensionDate;
        _ = this.Name;
        _ = this.NextExpectedMatch;
        _ = this.NextExpectedMatchDiff;
        _ = this.Notes;
        _ = this.ObjectGroupID;
        _ = this.ObjectGroupOrder;
        _ = this.ObjectGroupTitle;
        _ = this.ObjectHasCurrencySetting;
        _ = this.Order;
        foreach (var item in this.PaidDates ?? [])
        {
            item.Validate();
        }
        _ = this.PayDates;
        _ = this.PcAmountAvg;
        _ = this.PcAmountMax;
        _ = this.PcAmountMin;
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencyName;
        _ = this.PrimaryCurrencySymbol;
        this.RepeatFreq?.Validate();
        _ = this.Skip;
        _ = this.UpdatedAt;
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

[JsonConverter(typeof(JsonModelConverter<PaidDate, PaidDateFromRaw>))]
public sealed record class PaidDate : JsonModel
{
    /// <summary>
    /// The amount that was paid for this subscription in the subscription's currency.
    /// </summary>
    public string? Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("amount", value);
        }
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
    /// Date the bill was paid.
    /// </summary>
    public DateTimeOffset? Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("date", value);
        }
    }

    /// <summary>
    /// The foreign amount that was paid for this subscription in the subscription's currency.
    /// </summary>
    public string? ForeignAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("foreign_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("foreign_amount", value);
        }
    }

    /// <summary>
    /// The amount that was paid for this subscription in the administration's primary currency.
    /// </summary>
    public string? PcAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pc_amount", value);
        }
    }

    /// <summary>
    /// The foreign amount that was paid for this subscription in the administration's
    /// primary currency.
    /// </summary>
    public string? PcForeignAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_foreign_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pc_foreign_amount", value);
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

    /// <summary>
    /// ID of this subscription.
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subscription_id", value);
        }
    }

    /// <summary>
    /// Transaction group ID of the transaction linked to this subscription.
    /// </summary>
    public string? TransactionGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transaction_group_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transaction_group_id", value);
        }
    }

    /// <summary>
    /// Transaction journal ID of the transaction linked to this subscription.
    /// </summary>
    public string? TransactionJournalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transaction_journal_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transaction_journal_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencyName;
        _ = this.CurrencySymbol;
        _ = this.Date;
        _ = this.ForeignAmount;
        _ = this.PcAmount;
        _ = this.PcForeignAmount;
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencyName;
        _ = this.PrimaryCurrencySymbol;
        _ = this.SubscriptionID;
        _ = this.TransactionGroupID;
        _ = this.TransactionJournalID;
    }

    public PaidDate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaidDate(PaidDate paidDate)
        : base(paidDate) { }
#pragma warning restore CS8618

    public PaidDate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaidDate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaidDateFromRaw.FromRawUnchecked"/>
    public static PaidDate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaidDateFromRaw : IFromRawJson<PaidDate>
{
    /// <inheritdoc/>
    public PaidDate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaidDate.FromRawUnchecked(rawData);
}
