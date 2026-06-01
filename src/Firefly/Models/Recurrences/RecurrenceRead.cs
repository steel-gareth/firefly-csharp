using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Attachments = Firefly.Models.Attachments;

namespace Firefly.Models.Recurrences;

[JsonConverter(typeof(JsonModelConverter<RecurrenceRead, RecurrenceReadFromRaw>))]
public sealed record class RecurrenceRead : JsonModel
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

    public required Attachments::ObjectLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Attachments::ObjectLink>("links");
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

    public RecurrenceRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecurrenceRead(RecurrenceRead recurrenceRead)
        : base(recurrenceRead) { }
#pragma warning restore CS8618

    public RecurrenceRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurrenceRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurrenceReadFromRaw.FromRawUnchecked"/>
    public static RecurrenceRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurrenceReadFromRaw : IFromRawJson<RecurrenceRead>
{
    /// <inheritdoc/>
    public RecurrenceRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RecurrenceRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    /// <summary>
    /// If the recurrence is even active.
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
    /// Whether or not to fire the rules after the creation of a transaction.
    /// </summary>
    public bool? ApplyRules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("apply_rules");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apply_rules", value);
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
    /// Not to be confused with the description of the actual transaction(s) being created.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// First time the recurring transaction will fire. Must be after today.
    /// </summary>
    public string? FirstDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("first_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("first_date", value);
        }
    }

    /// <summary>
    /// Last time the recurring transaction has fired.
    /// </summary>
    public string? LatestDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("latest_date");
        }
        init { this._rawData.Set("latest_date", value); }
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
    /// Max number of created transactions. Use either this field or repeat_until.
    /// </summary>
    public int? NrOfRepetitions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("nr_of_repetitions");
        }
        init { this._rawData.Set("nr_of_repetitions", value); }
    }

    /// <summary>
    /// Date until the recurring transaction can fire. Use either this field or repetitions.
    /// </summary>
    public string? RepeatUntil
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("repeat_until");
        }
        init { this._rawData.Set("repeat_until", value); }
    }

    public IReadOnlyList<AttributesRepetition>? Repetitions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AttributesRepetition>>(
                "repetitions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AttributesRepetition>?>(
                "repetitions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    public IReadOnlyList<AttributesTransaction>? Transactions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AttributesTransaction>>(
                "transactions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AttributesTransaction>?>(
                "transactions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, RecurrenceTransactionType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecurrenceTransactionType>>(
                "type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
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
        _ = this.ApplyRules;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.FirstDate;
        _ = this.LatestDate;
        _ = this.Notes;
        _ = this.NrOfRepetitions;
        _ = this.RepeatUntil;
        foreach (var item in this.Repetitions ?? [])
        {
            item.Validate();
        }
        _ = this.Title;
        foreach (var item in this.Transactions ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
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

[JsonConverter(typeof(JsonModelConverter<AttributesRepetition, AttributesRepetitionFromRaw>))]
public sealed record class AttributesRepetition : JsonModel
{
    /// <summary>
    /// Information that defined the type of repetition. - For 'daily', this is empty.
    /// - For 'weekly', it is day of the week between 1 and 7 (Monday - Sunday). -
    /// For 'ndom', it is '1,2' or '4,5' or something else, where the first number
    /// is the week in the month, and the second number is the day in the week (between
    /// 1 and 7). '2,3' means: the 2nd Wednesday of the month - For 'monthly' it
    /// is the day of the month (1 - 31) - For yearly, it is a full date, ie '2026-04-01'.
    /// The year you use does not matter.
    /// </summary>
    public required string Moment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("moment");
        }
        init { this._rawData.Set("moment", value); }
    }

    /// <summary>
    /// The type of the repetition. ndom means: the n-th weekday of the month, where
    /// you can also specify which day of the week.
    /// </summary>
    public required ApiEnum<string, RecurrenceRepetitionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecurrenceRepetitionType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
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
    /// Auto-generated repetition description.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Array of future dates when the repetition will apply to. Auto generated.
    /// </summary>
    public IReadOnlyList<DateTimeOffset>? Occurrences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DateTimeOffset>>("occurrences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DateTimeOffset>?>(
                "occurrences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How many occurrences to skip. 0 means skip nothing. 1 means every other.
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

    /// <summary>
    /// How to respond when the recurring transaction falls in the weekend. Possible
    /// values: 1. Do nothing, just create it 2. Create no transaction. 3. Skip to
    /// the previous Friday. 4. Skip to the next Monday.
    /// </summary>
    public int? Weekend
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("weekend");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("weekend", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Moment;
        this.Type.Validate();
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Occurrences;
        _ = this.Skip;
        _ = this.UpdatedAt;
        _ = this.Weekend;
    }

    public AttributesRepetition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttributesRepetition(AttributesRepetition attributesRepetition)
        : base(attributesRepetition) { }
#pragma warning restore CS8618

    public AttributesRepetition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttributesRepetition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttributesRepetitionFromRaw.FromRawUnchecked"/>
    public static AttributesRepetition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttributesRepetitionFromRaw : IFromRawJson<AttributesRepetition>
{
    /// <inheritdoc/>
    public AttributesRepetition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AttributesRepetition.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AttributesTransaction, AttributesTransactionFromRaw>))]
public sealed record class AttributesTransaction : JsonModel
{
    /// <summary>
    /// Amount of the transaction.
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// The budget ID for this transaction.
    /// </summary>
    public string? BudgetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("budget_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("budget_id", value);
        }
    }

    /// <summary>
    /// The name of the budget to be used. If the budget name is unknown, the ID
    /// will be used or the value will be ignored.
    /// </summary>
    public string? BudgetName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("budget_name");
        }
        init { this._rawData.Set("budget_name", value); }
    }

    /// <summary>
    /// Category ID for this transaction.
    /// </summary>
    public string? CategoryID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category_id", value);
        }
    }

    /// <summary>
    /// Category name for this transaction.
    /// </summary>
    public string? CategoryName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category_name", value);
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

    public string? DestinationIban
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destination_iban");
        }
        init { this._rawData.Set("destination_iban", value); }
    }

    /// <summary>
    /// ID of the destination account. Submit either this or destination_name.
    /// </summary>
    public string? DestinationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destination_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("destination_id", value);
        }
    }

    /// <summary>
    /// Name of the destination account. Submit either this or destination_id.
    /// </summary>
    public string? DestinationName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destination_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("destination_name", value);
        }
    }

    public ApiEnum<string, AccountTypeProperty>? DestinationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AccountTypeProperty>>(
                "destination_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("destination_type", value);
        }
    }

    /// <summary>
    /// Foreign amount of the transaction.
    /// </summary>
    public string? ForeignAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("foreign_amount");
        }
        init { this._rawData.Set("foreign_amount", value); }
    }

    public string? ForeignCurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("foreign_currency_code");
        }
        init { this._rawData.Set("foreign_currency_code", value); }
    }

    /// <summary>
    /// Number of decimals in the currency
    /// </summary>
    public int? ForeignCurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("foreign_currency_decimal_places");
        }
        init { this._rawData.Set("foreign_currency_decimal_places", value); }
    }

    public string? ForeignCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("foreign_currency_id");
        }
        init { this._rawData.Set("foreign_currency_id", value); }
    }

    public string? ForeignCurrencyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("foreign_currency_name");
        }
        init { this._rawData.Set("foreign_currency_name", value); }
    }

    public string? ForeignCurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("foreign_currency_symbol");
        }
        init { this._rawData.Set("foreign_currency_symbol", value); }
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
    /// Amount of the transaction in primary currency.
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
    /// Foreign amount of the transaction.
    /// </summary>
    public string? PcForeignAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_foreign_amount");
        }
        init { this._rawData.Set("pc_foreign_amount", value); }
    }

    public string? PiggyBankID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("piggy_bank_id");
        }
        init { this._rawData.Set("piggy_bank_id", value); }
    }

    public string? PiggyBankName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("piggy_bank_name");
        }
        init { this._rawData.Set("piggy_bank_name", value); }
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

    public string? SourceIban
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_iban");
        }
        init { this._rawData.Set("source_iban", value); }
    }

    /// <summary>
    /// ID of the source account. Submit either this or source_name.
    /// </summary>
    public string? SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source_id", value);
        }
    }

    /// <summary>
    /// Name of the source account. Submit either this or source_id.
    /// </summary>
    public string? SourceName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source_name", value);
        }
    }

    public ApiEnum<string, AccountTypeProperty>? SourceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AccountTypeProperty>>(
                "source_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source_type", value);
        }
    }

    public string? SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    public string? SubscriptionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_name");
        }
        init { this._rawData.Set("subscription_name", value); }
    }

    /// <summary>
    /// Array of tags.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Description;
        _ = this.ID;
        _ = this.BudgetID;
        _ = this.BudgetName;
        _ = this.CategoryID;
        _ = this.CategoryName;
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencyName;
        _ = this.CurrencySymbol;
        _ = this.DestinationIban;
        _ = this.DestinationID;
        _ = this.DestinationName;
        this.DestinationType?.Validate();
        _ = this.ForeignAmount;
        _ = this.ForeignCurrencyCode;
        _ = this.ForeignCurrencyDecimalPlaces;
        _ = this.ForeignCurrencyID;
        _ = this.ForeignCurrencyName;
        _ = this.ForeignCurrencySymbol;
        _ = this.ObjectHasCurrencySetting;
        _ = this.PcAmount;
        _ = this.PcForeignAmount;
        _ = this.PiggyBankID;
        _ = this.PiggyBankName;
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencyName;
        _ = this.PrimaryCurrencySymbol;
        _ = this.SourceIban;
        _ = this.SourceID;
        _ = this.SourceName;
        this.SourceType?.Validate();
        _ = this.SubscriptionID;
        _ = this.SubscriptionName;
        _ = this.Tags;
    }

    public AttributesTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttributesTransaction(AttributesTransaction attributesTransaction)
        : base(attributesTransaction) { }
#pragma warning restore CS8618

    public AttributesTransaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AttributesTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttributesTransactionFromRaw.FromRawUnchecked"/>
    public static AttributesTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttributesTransactionFromRaw : IFromRawJson<AttributesTransaction>
{
    /// <inheritdoc/>
    public AttributesTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AttributesTransaction.FromRawUnchecked(rawData);
}
