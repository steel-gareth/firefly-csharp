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
/// Update existing recurring transaction.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RecurrenceUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

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

    /// <summary>
    /// First time the recurring transaction will fire.
    /// </summary>
    public string? FirstDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("first_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("first_date", value);
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

    /// <summary>
    /// Date until when the recurring transaction can fire. After that date, it's
    /// basically inactive. Use either this field or repetitions.
    /// </summary>
    public string? RepeatUntil
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("repeat_until");
        }
        init { this._rawBodyData.Set("repeat_until", value); }
    }

    public IReadOnlyList<RecurrenceUpdateParamsRepetition>? Repetitions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<RecurrenceUpdateParamsRepetition>
            >("repetitions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<RecurrenceUpdateParamsRepetition>?>(
                "repetitions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Title
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("title", value);
        }
    }

    public IReadOnlyList<RecurrenceUpdateParamsTransaction>? Transactions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<RecurrenceUpdateParamsTransaction>
            >("transactions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<RecurrenceUpdateParamsTransaction>?>(
                "transactions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public RecurrenceUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecurrenceUpdateParams(RecurrenceUpdateParams recurrenceUpdateParams)
        : base(recurrenceUpdateParams)
    {
        this.ID = recurrenceUpdateParams.ID;

        this._rawBodyData = new(recurrenceUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RecurrenceUpdateParams(
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
    RecurrenceUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RecurrenceUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(RecurrenceUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/recurrences/{0}", this.ID)
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

[JsonConverter(
    typeof(JsonModelConverter<
        RecurrenceUpdateParamsRepetition,
        RecurrenceUpdateParamsRepetitionFromRaw
    >)
)]
public sealed record class RecurrenceUpdateParamsRepetition : JsonModel
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
    public string? Moment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("moment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("moment", value);
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

    /// <summary>
    /// The type of the repetition. ndom means: the n-th weekday of the month, where
    /// you can also specify which day of the week.
    /// </summary>
    public ApiEnum<string, RecurrenceRepetitionType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecurrenceRepetitionType>>(
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
        _ = this.Skip;
        this.Type?.Validate();
        _ = this.Weekend;
    }

    public RecurrenceUpdateParamsRepetition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecurrenceUpdateParamsRepetition(
        RecurrenceUpdateParamsRepetition recurrenceUpdateParamsRepetition
    )
        : base(recurrenceUpdateParamsRepetition) { }
#pragma warning restore CS8618

    public RecurrenceUpdateParamsRepetition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurrenceUpdateParamsRepetition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurrenceUpdateParamsRepetitionFromRaw.FromRawUnchecked"/>
    public static RecurrenceUpdateParamsRepetition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecurrenceUpdateParamsRepetitionFromRaw : IFromRawJson<RecurrenceUpdateParamsRepetition>
{
    /// <inheritdoc/>
    public RecurrenceUpdateParamsRepetition FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecurrenceUpdateParamsRepetition.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        RecurrenceUpdateParamsTransaction,
        RecurrenceUpdateParamsTransactionFromRaw
    >)
)]
public sealed record class RecurrenceUpdateParamsTransaction : JsonModel
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

    /// <summary>
    /// Amount of the transaction.
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
    public string? ForeignCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("foreign_currency_id");
        }
        init { this._rawData.Set("foreign_currency_id", value); }
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
        _ = this.ID;
        _ = this.Amount;
        _ = this.BillID;
        _ = this.BudgetID;
        _ = this.CategoryID;
        _ = this.CurrencyCode;
        _ = this.CurrencyID;
        _ = this.Description;
        _ = this.DestinationID;
        _ = this.ForeignAmount;
        _ = this.ForeignCurrencyID;
        _ = this.PiggyBankID;
        _ = this.SourceID;
        _ = this.Tags;
    }

    public RecurrenceUpdateParamsTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecurrenceUpdateParamsTransaction(
        RecurrenceUpdateParamsTransaction recurrenceUpdateParamsTransaction
    )
        : base(recurrenceUpdateParamsTransaction) { }
#pragma warning restore CS8618

    public RecurrenceUpdateParamsTransaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurrenceUpdateParamsTransaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurrenceUpdateParamsTransactionFromRaw.FromRawUnchecked"/>
    public static RecurrenceUpdateParamsTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RecurrenceUpdateParamsTransaction(string id)
        : this()
    {
        this.ID = id;
    }
}

class RecurrenceUpdateParamsTransactionFromRaw : IFromRawJson<RecurrenceUpdateParamsTransaction>
{
    /// <inheritdoc/>
    public RecurrenceUpdateParamsTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecurrenceUpdateParamsTransaction.FromRawUnchecked(rawData);
}
