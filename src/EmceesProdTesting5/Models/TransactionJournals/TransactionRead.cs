using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using Attachments = EmceesProdTesting5.Models.Attachments;
using Recurrences = EmceesProdTesting5.Models.Recurrences;
using Transactions = EmceesProdTesting5.Models.Transactions;

namespace EmceesProdTesting5.Models.TransactionJournals;

[JsonConverter(typeof(JsonModelConverter<TransactionRead, TransactionReadFromRaw>))]
public sealed record class TransactionRead : JsonModel
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

    public TransactionRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionRead(TransactionRead transactionRead)
        : base(transactionRead) { }
#pragma warning restore CS8618

    public TransactionRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransactionRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransactionReadFromRaw.FromRawUnchecked"/>
    public static TransactionRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransactionReadFromRaw : IFromRawJson<TransactionRead>
{
    /// <inheritdoc/>
    public TransactionRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TransactionRead.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Attributes, AttributesFromRaw>))]
public sealed record class Attributes : JsonModel
{
    public required IReadOnlyList<Transaction> Transactions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Transaction>>("transactions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Transaction>>(
                "transactions",
                ImmutableArray.ToImmutableArray(value)
            );
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
    /// Title of the transaction if it has been split in more than one piece. Empty otherwise.
    /// </summary>
    public string? GroupTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("group_title");
        }
        init { this._rawData.Set("group_title", value); }
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
    /// User ID
    /// </summary>
    public string? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Transactions)
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.GroupTitle;
        _ = this.UpdatedAt;
        _ = this.User;
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
    public Attributes(IReadOnlyList<Transaction> transactions)
        : this()
    {
        this.Transactions = transactions;
    }
}

class AttributesFromRaw : IFromRawJson<Attributes>
{
    /// <inheritdoc/>
    public Attributes FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attributes.FromRawUnchecked(rawData);
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

    /// <summary>
    /// Date of the transaction
    /// </summary>
    public required DateTimeOffset Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("date");
        }
        init { this._rawData.Set("date", value); }
    }

    /// <summary>
    /// Description of the transaction.
    /// </summary>
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
    /// ID of the destination account. For a deposit or a transfer, this must always
    /// be an asset account. For withdrawals this must be an expense account.
    /// </summary>
    public required string? DestinationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destination_id");
        }
        init { this._rawData.Set("destination_id", value); }
    }

    /// <summary>
    /// ID of the source account. For a withdrawal or a transfer, this must always
    /// be an asset account. For deposits, this must be a revenue account.
    /// </summary>
    public required string? SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_id");
        }
        init { this._rawData.Set("source_id", value); }
    }

    public required ApiEnum<string, Transactions::TransactionTypeProperty> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, Transactions::TransactionTypeProperty>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The associated subscription ID for this transaction. `bill` refers to the
    /// OLD name for subscriptions and this field will be removed.
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
    /// The associated subscription name for this transaction. `bill` refers to the
    /// OLD name for subscriptions and this field will be removed.
    /// </summary>
    public string? BillName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bill_name");
        }
        init { this._rawData.Set("bill_name", value); }
    }

    public DateTimeOffset? BookDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("book_date");
        }
        init { this._rawData.Set("book_date", value); }
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
        init { this._rawData.Set("budget_id", value); }
    }

    /// <summary>
    /// The name of the budget used.
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
    /// The category ID for this transaction.
    /// </summary>
    public string? CategoryID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category_id");
        }
        init { this._rawData.Set("category_id", value); }
    }

    /// <summary>
    /// The name of the category to be used. If the category is unknown, it will be
    /// created. If the ID and the name point to different categories, the ID overrules
    /// the name.
    /// </summary>
    public string? CategoryName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category_name");
        }
        init { this._rawData.Set("category_name", value); }
    }

    /// <summary>
    /// Currency code for the currency of this transaction.
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
    /// Number of decimals used in this currency.
    /// </summary>
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
    /// Currency ID for the currency of this transaction.
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
    /// Currency name for the currency of this transaction.
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

    /// <summary>
    /// Currency symbol for the currency of this transaction.
    /// </summary>
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
    /// The balance of the destination account. This is the balance in the account's
    /// currency which may be different from this transaction, and is not provided
    /// in this model.
    /// </summary>
    public string? DestinationBalanceAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destination_balance_after");
        }
        init { this._rawData.Set("destination_balance_after", value); }
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
    /// Name of the destination account. You can submit the name instead of the ID.
    /// For everything except transfers, the account will be auto-generated if unknown,
    /// so submitting a name is enough.
    /// </summary>
    public string? DestinationName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destination_name");
        }
        init { this._rawData.Set("destination_name", value); }
    }

    public ApiEnum<string, Recurrences::AccountTypeProperty>? DestinationType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, Recurrences::AccountTypeProperty>
            >("destination_type");
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

    public DateTimeOffset? DueDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("due_date");
        }
        init { this._rawData.Set("due_date", value); }
    }

    /// <summary>
    /// Reference to external ID in other systems.
    /// </summary>
    public string? ExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_id");
        }
        init { this._rawData.Set("external_id", value); }
    }

    /// <summary>
    /// External, custom URL for this transaction.
    /// </summary>
    public string? ExternalUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_url");
        }
        init { this._rawData.Set("external_url", value); }
    }

    /// <summary>
    /// The amount in the set foreign currency. May be NULL if the transaction does
    /// not have a foreign amount.
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
    /// Currency code of the foreign currency. Default is NULL.
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
    /// Number of decimals in the foreign currency.
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

    /// <summary>
    /// Currency ID of the foreign currency, if this transaction has a foreign amount.
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
    /// If the transaction has attachments.
    /// </summary>
    public bool? HasAttachments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_attachments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("has_attachments", value);
        }
    }

    /// <summary>
    /// Hash value of original import transaction (for duplicate detection).
    /// </summary>
    public string? ImportHashV2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("import_hash_v2");
        }
        init { this._rawData.Set("import_hash_v2", value); }
    }

    public DateTimeOffset? InterestDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("interest_date");
        }
        init { this._rawData.Set("interest_date", value); }
    }

    /// <summary>
    /// Reference to internal reference of other systems.
    /// </summary>
    public string? InternalReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("internal_reference");
        }
        init { this._rawData.Set("internal_reference", value); }
    }

    public DateTimeOffset? InvoiceDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("invoice_date");
        }
        init { this._rawData.Set("invoice_date", value); }
    }

    /// <summary>
    /// Latitude of the transaction's location, if applicable. Can be used to draw
    /// a map.
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
    /// Latitude of the transaction's location, if applicable. Can be used to draw
    /// a map.
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
    /// Indicates whether the transaction has a currency setting. For transactions
    /// this is always true.
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
    /// Order of this entry in the list of transactions.
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
    /// System generated identifier for original creator of transaction.
    /// </summary>
    public string? OriginalSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("original_source");
        }
        init { this._rawData.Set("original_source", value); }
    }

    public DateTimeOffset? PaymentDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("payment_date");
        }
        init { this._rawData.Set("payment_date", value); }
    }

    /// <summary>
    /// Amount of the transaction in the primary currency of this administration.
    /// The `primary_currency_*` fields reflect the currency used. This field is NULL
    /// if the user does have 'convert to primary' set to true in their settings.
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
    /// The balance of the destination account in the primary currency of this administration.
    /// The `primary_currency_*` fields reflect the currency used. This field is NULL
    /// if the user does have 'convert to primary' set to true in their settings.
    /// </summary>
    public string? PcDestinationBalanceAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_destination_balance_after");
        }
        init { this._rawData.Set("pc_destination_balance_after", value); }
    }

    /// <summary>
    /// Foreign amount of the transaction in the primary currency of this administration.
    /// The `primary_currency_*` fields reflect the currency used. This field is
    /// NULL if the user does have 'convert to primary' set to true in their settings.
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
    /// The balance of the source account in the primary currency of this administration.
    /// The `primary_currency_*` fields reflect the currency used. This field is NULL
    /// if the user does have 'convert to primary' set to true in their settings.
    /// </summary>
    public string? PcSourceBalanceAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pc_source_balance_after");
        }
        init { this._rawData.Set("pc_source_balance_after", value); }
    }

    /// <summary>
    /// Returns the primary currency code of the administration. This currency is
    /// used as the currency for all `pc_*` amount and balance fields of this account.
    /// </summary>
    public string? PrimaryCurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_currency_code");
        }
        init { this._rawData.Set("primary_currency_code", value); }
    }

    /// <summary>
    /// See the other `primary_*` fields.
    /// </summary>
    public int? PrimaryCurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("primary_currency_decimal_places");
        }
        init { this._rawData.Set("primary_currency_decimal_places", value); }
    }

    /// <summary>
    /// Returns the primary currency ID of the administration. This currency is used
    /// as the currency for all `pc_*` amount and balance fields of this account.
    /// </summary>
    public string? PrimaryCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_currency_id");
        }
        init { this._rawData.Set("primary_currency_id", value); }
    }

    /// <summary>
    /// See the other `primary_*` fields.
    /// </summary>
    public string? PrimaryCurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_currency_symbol");
        }
        init { this._rawData.Set("primary_currency_symbol", value); }
    }

    public DateTimeOffset? ProcessDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("process_date");
        }
        init { this._rawData.Set("process_date", value); }
    }

    /// <summary>
    /// If the transaction has been reconciled already. When you set this, the amount
    /// can no longer be edited by the user.
    /// </summary>
    public bool? Reconciled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("reconciled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reconciled", value);
        }
    }

    /// <summary>
    /// The # of the current transaction created under this recurrence.
    /// </summary>
    public int? RecurrenceCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("recurrence_count");
        }
        init { this._rawData.Set("recurrence_count", value); }
    }

    /// <summary>
    /// Reference to recurrence that made the transaction.
    /// </summary>
    public string? RecurrenceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recurrence_id");
        }
        init { this._rawData.Set("recurrence_id", value); }
    }

    /// <summary>
    /// Total number of transactions expected to be created by this recurrence repetition.
    /// Will be 0 if infinite.
    /// </summary>
    public int? RecurrenceTotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("recurrence_total");
        }
        init { this._rawData.Set("recurrence_total", value); }
    }

    /// <summary>
    /// SEPA Batch ID
    /// </summary>
    public string? SepaBatchID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sepa_batch_id");
        }
        init { this._rawData.Set("sepa_batch_id", value); }
    }

    /// <summary>
    /// SEPA Clearing Code
    /// </summary>
    public string? SepaCc
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sepa_cc");
        }
        init { this._rawData.Set("sepa_cc", value); }
    }

    /// <summary>
    /// SEPA Creditor Identifier
    /// </summary>
    public string? SepaCi
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sepa_ci");
        }
        init { this._rawData.Set("sepa_ci", value); }
    }

    /// <summary>
    /// SEPA Country
    /// </summary>
    public string? SepaCountry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sepa_country");
        }
        init { this._rawData.Set("sepa_country", value); }
    }

    /// <summary>
    /// SEPA end-to-end Identifier
    /// </summary>
    public string? SepaCtID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sepa_ct_id");
        }
        init { this._rawData.Set("sepa_ct_id", value); }
    }

    /// <summary>
    /// SEPA Opposing Account Identifier
    /// </summary>
    public string? SepaCtOp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sepa_ct_op");
        }
        init { this._rawData.Set("sepa_ct_op", value); }
    }

    /// <summary>
    /// SEPA mandate identifier
    /// </summary>
    public string? SepaDB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sepa_db");
        }
        init { this._rawData.Set("sepa_db", value); }
    }

    /// <summary>
    /// SEPA External Purpose indicator
    /// </summary>
    public string? SepaEp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sepa_ep");
        }
        init { this._rawData.Set("sepa_ep", value); }
    }

    /// <summary>
    /// The balance of the source account. This is the balance in the account's currency
    /// which may be different from this transaction, and is not provided in this model.
    /// </summary>
    public string? SourceBalanceAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_balance_after");
        }
        init { this._rawData.Set("source_balance_after", value); }
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
    /// Name of the source account. For a withdrawal or a transfer, this must always
    /// be an asset account. For deposits, this must be a revenue account. Can be
    /// used instead of the source_id. If the transaction is a deposit, the source_name
    /// can be filled in freely: the account will be created based on the name.
    /// </summary>
    public string? SourceName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_name");
        }
        init { this._rawData.Set("source_name", value); }
    }

    public ApiEnum<string, Recurrences::AccountTypeProperty>? SourceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, Recurrences::AccountTypeProperty>
            >("source_type");
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

    /// <summary>
    /// The associated subscription ID for this transaction.
    /// </summary>
    public string? SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <summary>
    /// The associated subscription name for this transaction.
    /// </summary>
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

    /// <summary>
    /// ID of the underlying transaction journal. Each transaction consists of a transaction
    /// group (see the top ID) and one or more journals making up the splits of the transaction.
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

    /// <summary>
    /// User ID
    /// </summary>
    public string? User
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user", value);
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
        _ = this.Amount;
        _ = this.Date;
        _ = this.Description;
        _ = this.DestinationID;
        _ = this.SourceID;
        this.Type.Validate();
        _ = this.BillID;
        _ = this.BillName;
        _ = this.BookDate;
        _ = this.BudgetID;
        _ = this.BudgetName;
        _ = this.CategoryID;
        _ = this.CategoryName;
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencyName;
        _ = this.CurrencySymbol;
        _ = this.DestinationBalanceAfter;
        _ = this.DestinationIban;
        _ = this.DestinationName;
        this.DestinationType?.Validate();
        _ = this.DueDate;
        _ = this.ExternalID;
        _ = this.ExternalUrl;
        _ = this.ForeignAmount;
        _ = this.ForeignCurrencyCode;
        _ = this.ForeignCurrencyDecimalPlaces;
        _ = this.ForeignCurrencyID;
        _ = this.ForeignCurrencySymbol;
        _ = this.HasAttachments;
        _ = this.ImportHashV2;
        _ = this.InterestDate;
        _ = this.InternalReference;
        _ = this.InvoiceDate;
        _ = this.Latitude;
        _ = this.Longitude;
        _ = this.Notes;
        _ = this.ObjectHasCurrencySetting;
        _ = this.Order;
        _ = this.OriginalSource;
        _ = this.PaymentDate;
        _ = this.PcAmount;
        _ = this.PcDestinationBalanceAfter;
        _ = this.PcForeignAmount;
        _ = this.PcSourceBalanceAfter;
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencySymbol;
        _ = this.ProcessDate;
        _ = this.Reconciled;
        _ = this.RecurrenceCount;
        _ = this.RecurrenceID;
        _ = this.RecurrenceTotal;
        _ = this.SepaBatchID;
        _ = this.SepaCc;
        _ = this.SepaCi;
        _ = this.SepaCountry;
        _ = this.SepaCtID;
        _ = this.SepaCtOp;
        _ = this.SepaDB;
        _ = this.SepaEp;
        _ = this.SourceBalanceAfter;
        _ = this.SourceIban;
        _ = this.SourceName;
        this.SourceType?.Validate();
        _ = this.SubscriptionID;
        _ = this.SubscriptionName;
        _ = this.Tags;
        _ = this.TransactionJournalID;
        _ = this.User;
        _ = this.ZoomLevel;
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
