using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using AvailableBudgets = EmceesProdTesting5.Models.AvailableBudgets;

namespace EmceesProdTesting5.Models.Categories;

[JsonConverter(typeof(JsonModelConverter<CategoryRead, CategoryReadFromRaw>))]
public sealed record class CategoryRead : JsonModel
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

    public CategoryRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CategoryRead(CategoryRead categoryRead)
        : base(categoryRead) { }
#pragma warning restore CS8618

    public CategoryRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategoryRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategoryReadFromRaw.FromRawUnchecked"/>
    public static CategoryRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CategoryReadFromRaw : IFromRawJson<CategoryRead>
{
    /// <inheritdoc/>
    public CategoryRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CategoryRead.FromRawUnchecked(rawData);
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
    /// Amount(s) earned in the currencies in the database for this category. ONLY
    /// present when start and date are set.
    /// </summary>
    public IReadOnlyList<AvailableBudgets::ArrayEntryWithCurrencyAndSum>? Earned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>
            >("earned");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>?>(
                "earned",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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
    /// This object never has its own currency setting, so this value is always false.
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
    /// Amount(s) earned in the primary currency in the database for this category.
    /// ONLY present when start and date are set.
    /// </summary>
    public IReadOnlyList<AvailableBudgets::ArrayEntryWithCurrencyAndSum>? PcEarned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>
            >("pc_earned");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>?>(
                "pc_earned",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Amount(s) spent in the primary currency in the database for this category.
    /// ONLY present when start and date are set.
    /// </summary>
    public IReadOnlyList<AvailableBudgets::ArrayEntryWithCurrencyAndSum>? PcSpent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>
            >("pc_spent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>?>(
                "pc_spent",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Amount(s) transferred in primary currency in the database for this category.
    /// ONLY present when start and date are set.
    /// </summary>
    public IReadOnlyList<AvailableBudgets::ArrayEntryWithCurrencyAndSum>? PcTransferred
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>
            >("pc_transferred");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>?>(
                "pc_transferred",
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

    /// <summary>
    /// Amount(s) spent in the currencies in the database for this category. ONLY
    /// present when start and date are set.
    /// </summary>
    public IReadOnlyList<AvailableBudgets::ArrayEntryWithCurrencyAndSum>? Spent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>
            >("spent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>?>(
                "spent",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Amount(s) transferred in the currencies in the database for this category.
    /// ONLY present when start and date are set.
    /// </summary>
    public IReadOnlyList<AvailableBudgets::ArrayEntryWithCurrencyAndSum>? Transferred
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>
            >("transferred");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AvailableBudgets::ArrayEntryWithCurrencyAndSum>?>(
                "transferred",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        _ = this.Name;
        _ = this.CreatedAt;
        foreach (var item in this.Earned ?? [])
        {
            item.Validate();
        }
        _ = this.Notes;
        _ = this.ObjectHasCurrencySetting;
        foreach (var item in this.PcEarned ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PcSpent ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.PcTransferred ?? [])
        {
            item.Validate();
        }
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencyName;
        _ = this.PrimaryCurrencySymbol;
        foreach (var item in this.Spent ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Transferred ?? [])
        {
            item.Validate();
        }
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

    [SetsRequiredMembers]
    public Attributes(string name)
        : this()
    {
        this.Name = name;
    }
}

class AttributesFromRaw : IFromRawJson<Attributes>
{
    /// <inheritdoc/>
    public Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attributes.FromRawUnchecked(rawData);
}
