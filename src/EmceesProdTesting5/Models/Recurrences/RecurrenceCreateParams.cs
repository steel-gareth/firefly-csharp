using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Recurrences;

/// <summary>
/// Creates a new recurring transaction. The data required can be submitted as a JSON
/// body or as a list of parameters.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RecurrenceCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// First time the recurring transaction will fire. Must be after today.
    /// </summary>
    public required string FirstDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("first_date");
        }
        init { this._rawBodyData.Set("first_date", value); }
    }

    /// <summary>
    /// Date until the recurring transaction can fire. Use either this field or repetitions.
    /// </summary>
    public required string? RepeatUntil
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("repeat_until");
        }
        init { this._rawBodyData.Set("repeat_until", value); }
    }

    public required IReadOnlyList<Repetition> Repetitions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Repetition>>("repetitions");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Repetition>>(
                "repetitions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Title
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("title");
        }
        init { this._rawBodyData.Set("title", value); }
    }

    public required IReadOnlyList<Transaction> Transactions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Transaction>>("transactions");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Transaction>>(
                "transactions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, RecurrenceTransactionType> Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, RecurrenceTransactionType>>(
                "type"
            );
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// If the recurrence is even active.
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
    /// Whether or not to fire the rules after the creation of a transaction.
    /// </summary>
    public bool? ApplyRules
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("apply_rules");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("apply_rules", value);
        }
    }

    /// <summary>
    /// Not to be confused with the description of the actual transaction(s) being created.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
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
    /// Max number of created transactions. Use either this field or repeat_until.
    /// </summary>
    public int? NrOfRepetitions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>("nr_of_repetitions");
        }
        init { this._rawBodyData.Set("nr_of_repetitions", value); }
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

    public RecurrenceCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecurrenceCreateParams(RecurrenceCreateParams recurrenceCreateParams)
        : base(recurrenceCreateParams)
    {
        this._rawBodyData = new(recurrenceCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RecurrenceCreateParams(
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
    RecurrenceCreateParams(
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
    public static RecurrenceCreateParams FromRawUnchecked(
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

    public virtual bool Equals(RecurrenceCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/recurrences")
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

[JsonConverter(typeof(JsonModelConverter<Repetition, RepetitionFromRaw>))]
public sealed record class Repetition : JsonModel
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
        _ = this.Skip;
        _ = this.Weekend;
    }

    public Repetition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Repetition(Repetition repetition)
        : base(repetition) { }
#pragma warning restore CS8618

    public Repetition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Repetition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RepetitionFromRaw.FromRawUnchecked"/>
    public static Repetition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RepetitionFromRaw : IFromRawJson<Repetition>
{
    /// <inheritdoc/>
    public Repetition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Repetition.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Transaction, TransactionFromRaw>))]
public sealed record class Transaction : JsonModel
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

    /// <summary>
    /// ID of the destination account.
    /// </summary>
    public required string DestinationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("destination_id");
        }
        init { this._rawData.Set("destination_id", value); }
    }

    /// <summary>
    /// ID of the source account.
    /// </summary>
    public required string SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source_id");
        }
        init { this._rawData.Set("source_id", value); }
    }

    /// <summary>
    /// Optional.
    /// </summary>
    public string? BillID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bill_id");
        }
        init { this._rawData.Set("bill_id", value); }
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
    /// Submit either a currency_id or a currency_code.
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

    /// <summary>
    /// Submit either a currency_id or a currency_code.
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

    /// <summary>
    /// Submit either a foreign_currency_id or a foreign_currency_code, or neither.
    /// </summary>
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
    /// Submit either a foreign_currency_id or a foreign_currency_code, or neither.
    /// </summary>
    public string? ForeignCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("foreign_currency_id");
        }
        init { this._rawData.Set("foreign_currency_id", value); }
    }

    /// <summary>
    /// Optional.
    /// </summary>
    public string? PiggyBankID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("piggy_bank_id");
        }
        init { this._rawData.Set("piggy_bank_id", value); }
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
        _ = this.DestinationID;
        _ = this.SourceID;
        _ = this.BillID;
        _ = this.BudgetID;
        _ = this.CategoryID;
        _ = this.CurrencyCode;
        _ = this.CurrencyID;
        _ = this.ForeignAmount;
        _ = this.ForeignCurrencyCode;
        _ = this.ForeignCurrencyID;
        _ = this.PiggyBankID;
        _ = this.Tags;
    }

    public Transaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transaction(Transaction transaction)
        : base(transaction) { }
#pragma warning restore CS8618

    public Transaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionFromRaw.FromRawUnchecked"/>
    public static Transaction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionFromRaw : IFromRawJson<Transaction>
{
    /// <inheritdoc/>
    public Transaction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transaction.FromRawUnchecked(rawData);
}
