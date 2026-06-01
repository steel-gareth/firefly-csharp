using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Models.PiggyBanks;

[JsonConverter(typeof(JsonModelConverter<PiggyBankRead, PiggyBankReadFromRaw>))]
public sealed record class PiggyBankRead : JsonModel
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

    public required PiggyBankReadAttributes Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PiggyBankReadAttributes>("attributes");
        }
        init { this._rawData.Set("attributes", value); }
    }

    public required ObjectLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ObjectLink>("links");
        }
        init { this._rawData.Set("links", value); }
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
        this.Links.Validate();
        _ = this.Type;
    }

    public PiggyBankRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PiggyBankRead(PiggyBankRead piggyBankRead)
        : base(piggyBankRead) { }
#pragma warning restore CS8618

    public PiggyBankRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PiggyBankRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PiggyBankReadFromRaw.FromRawUnchecked"/>
    public static PiggyBankRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PiggyBankReadFromRaw : IFromRawJson<PiggyBankRead>
{
    /// <inheritdoc/>
    public PiggyBankRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PiggyBankRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PiggyBankReadAttributes, PiggyBankReadAttributesFromRaw>))]
public sealed record class PiggyBankReadAttributes : JsonModel
{
    public required JsonElement AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string? TargetAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("target_amount");
        }
        init { this._rawData.Set("target_amount", value); }
    }

    public IReadOnlyList<PiggyBankReadAttributesAccount>? Accounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PiggyBankReadAttributesAccount>>(
                "accounts"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PiggyBankReadAttributesAccount>?>(
                "accounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public string? CurrentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("current_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("current_amount", value);
        }
    }

    public string? LeftToSave
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("left_to_save");
        }
        init { this._rawData.Set("left_to_save", value); }
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
    /// The current amount in the primary currency of the administration.
    /// </summary>
    public string? PcCurrentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_current_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pc_current_amount", value);
        }
    }

    public string? PcLeftToSave
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_left_to_save");
        }
        init { this._rawData.Set("pc_left_to_save", value); }
    }

    public string? PcSavePerMonth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_save_per_month");
        }
        init { this._rawData.Set("pc_save_per_month", value); }
    }

    /// <summary>
    /// The target amount in the primary currency of the administration.
    /// </summary>
    public string? PcTargetAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_target_amount");
        }
        init { this._rawData.Set("pc_target_amount", value); }
    }

    /// <summary>
    /// The percentage of the target amount that has been saved, if a target amount
    /// is set.
    /// </summary>
    public int? Percentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("percentage");
        }
        init { this._rawData.Set("percentage", value); }
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

    public string? SavePerMonth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("save_per_month");
        }
        init { this._rawData.Set("save_per_month", value); }
    }

    /// <summary>
    /// The date you started with this piggy bank.
    /// </summary>
    public DateTimeOffset? StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("start_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start_date", value);
        }
    }

    /// <summary>
    /// The date you intend to finish saving money.
    /// </summary>
    public DateTimeOffset? TargetDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("target_date");
        }
        init { this._rawData.Set("target_date", value); }
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
        _ = this.AccountID;
        _ = this.Name;
        _ = this.TargetAmount;
        foreach (var item in this.Accounts ?? [])
        {
            item.Validate();
        }
        _ = this.Active;
        _ = this.CreatedAt;
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencyName;
        _ = this.CurrencySymbol;
        _ = this.CurrentAmount;
        _ = this.LeftToSave;
        _ = this.Notes;
        _ = this.ObjectGroupID;
        _ = this.ObjectGroupOrder;
        _ = this.ObjectGroupTitle;
        _ = this.ObjectHasCurrencySetting;
        _ = this.Order;
        _ = this.PcCurrentAmount;
        _ = this.PcLeftToSave;
        _ = this.PcSavePerMonth;
        _ = this.PcTargetAmount;
        _ = this.Percentage;
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencyName;
        _ = this.PrimaryCurrencySymbol;
        _ = this.SavePerMonth;
        _ = this.StartDate;
        _ = this.TargetDate;
        _ = this.UpdatedAt;
    }

    public PiggyBankReadAttributes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PiggyBankReadAttributes(PiggyBankReadAttributes piggyBankReadAttributes)
        : base(piggyBankReadAttributes) { }
#pragma warning restore CS8618

    public PiggyBankReadAttributes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PiggyBankReadAttributes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PiggyBankReadAttributesFromRaw.FromRawUnchecked"/>
    public static PiggyBankReadAttributes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PiggyBankReadAttributesFromRaw : IFromRawJson<PiggyBankReadAttributes>
{
    /// <inheritdoc/>
    public PiggyBankReadAttributes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PiggyBankReadAttributes.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        PiggyBankReadAttributesAccount,
        PiggyBankReadAttributesAccountFromRaw
    >)
)]
public sealed record class PiggyBankReadAttributesAccount : JsonModel
{
    /// <summary>
    /// The ID of the account.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_id", value);
        }
    }

    public string? CurrentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("current_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("current_amount", value);
        }
    }

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
    /// If convertToPrimary is on, this will show the amount in the primary currency.
    /// </summary>
    public string? PcCurrentAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_current_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pc_current_amount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountID;
        _ = this.CurrentAmount;
        _ = this.Name;
        _ = this.PcCurrentAmount;
    }

    public PiggyBankReadAttributesAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PiggyBankReadAttributesAccount(
        PiggyBankReadAttributesAccount piggyBankReadAttributesAccount
    )
        : base(piggyBankReadAttributesAccount) { }
#pragma warning restore CS8618

    public PiggyBankReadAttributesAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PiggyBankReadAttributesAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PiggyBankReadAttributesAccountFromRaw.FromRawUnchecked"/>
    public static PiggyBankReadAttributesAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PiggyBankReadAttributesAccountFromRaw : IFromRawJson<PiggyBankReadAttributesAccount>
{
    /// <inheritdoc/>
    public PiggyBankReadAttributesAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PiggyBankReadAttributesAccount.FromRawUnchecked(rawData);
}
