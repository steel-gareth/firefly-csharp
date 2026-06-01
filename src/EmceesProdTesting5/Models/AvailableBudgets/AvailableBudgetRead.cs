using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.AvailableBudgets;

[JsonConverter(typeof(JsonModelConverter<AvailableBudgetRead, AvailableBudgetReadFromRaw>))]
public sealed record class AvailableBudgetRead : JsonModel
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

    public AvailableBudgetRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AvailableBudgetRead(AvailableBudgetRead availableBudgetRead)
        : base(availableBudgetRead) { }
#pragma warning restore CS8618

    public AvailableBudgetRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AvailableBudgetRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AvailableBudgetReadFromRaw.FromRawUnchecked"/>
    public static AvailableBudgetRead FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AvailableBudgetReadFromRaw : IFromRawJson<AvailableBudgetRead>
{
    /// <inheritdoc/>
    public AvailableBudgetRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AvailableBudgetRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    /// <summary>
    /// The amount of this available budget in the currency of this available budget.
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

    /// <summary>
    /// End date of the available budget.
    /// </summary>
    public DateTimeOffset? End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("end");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("end", value);
        }
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
    /// The amount of this available budget in the primary currency (pc) of this administration.
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
    /// The amount spent in budgets in the primary currency (pc) of this administration.
    /// </summary>
    public IReadOnlyList<ArrayEntryWithCurrencyAndSum>? PcSpentInBudgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ArrayEntryWithCurrencyAndSum>>(
                "pc_spent_in_budgets"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ArrayEntryWithCurrencyAndSum>?>(
                "pc_spent_in_budgets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The amount spent outside of budgets in the primary currency (pc) of this administration.
    /// </summary>
    public IReadOnlyList<ArrayEntryWithCurrencyAndSum>? PcSpentOutsideBudgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ArrayEntryWithCurrencyAndSum>>(
                "pc_spent_outside_budgets"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ArrayEntryWithCurrencyAndSum>?>(
                "pc_spent_outside_budgets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public IReadOnlyList<ArrayEntryWithCurrencyAndSum>? SpentInBudgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ArrayEntryWithCurrencyAndSum>>(
                "spent_in_budgets"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ArrayEntryWithCurrencyAndSum>?>(
                "spent_in_budgets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<ArrayEntryWithCurrencyAndSum>? SpentOutsideBudgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ArrayEntryWithCurrencyAndSum>>(
                "spent_outside_budgets"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ArrayEntryWithCurrencyAndSum>?>(
                "spent_outside_budgets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Start date of the available budget.
    /// </summary>
    public DateTimeOffset? Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("start");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start", value);
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
        _ = this.Amount;
        _ = this.CreatedAt;
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencyName;
        _ = this.CurrencySymbol;
        _ = this.End;
        _ = this.ObjectHasCurrencySetting;
        _ = this.PcAmount;
        foreach (var item in this.PcSpentInBudgets ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PcSpentOutsideBudgets ?? [])
        {
            item.Validate();
        }
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencyName;
        _ = this.PrimaryCurrencySymbol;
        foreach (var item in this.SpentInBudgets ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.SpentOutsideBudgets ?? [])
        {
            item.Validate();
        }
        _ = this.Start;
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
