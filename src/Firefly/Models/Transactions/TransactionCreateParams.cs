using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Transactions;

/// <summary>
/// Creates a new transaction. The data required can be submitted as a JSON body
/// or as a list of parameters.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TransactionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
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

    /// <summary>
    /// Whether or not to apply rules when submitting transaction.
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
    /// Break if the submitted transaction exists already.
    /// </summary>
    public bool? ErrorIfDuplicateHash
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("error_if_duplicate_hash");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("error_if_duplicate_hash", value);
        }
    }

    /// <summary>
    /// Whether or not to fire the webhooks that are related to this event.
    /// </summary>
    public bool? FireWebhooks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("fire_webhooks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("fire_webhooks", value);
        }
    }

    /// <summary>
    /// Title of the transaction if it has been split in more than one piece. Empty otherwise.
    /// </summary>
    public string? GroupTitle
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("group_title");
        }
        init { this._rawBodyData.Set("group_title", value); }
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

    public TransactionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransactionCreateParams(TransactionCreateParams transactionCreateParams)
        : base(transactionCreateParams)
    {
        this._rawBodyData = new(transactionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TransactionCreateParams(
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
    TransactionCreateParams(
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
    public static TransactionCreateParams FromRawUnchecked(
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

    public virtual bool Equals(TransactionCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/transactions")
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

    public required ApiEnum<string, TransactionTypeProperty> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TransactionTypeProperty>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Optional. Use either this or the bill_name
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
    /// Optional. Use either this or the bill_id
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
    /// Currency code. Default is the source account's currency, or the user's financial
    /// administration's primary currency. The value you submit may be overruled
    /// by the source or destination account.
    /// </summary>
    public string? CurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_code");
        }
        init { this._rawData.Set("currency_code", value); }
    }

    /// <summary>
    /// Currency ID. Default is the source account's currency, or the user's financial
    /// administration's currency. The value you submit may be overruled by the source
    /// or destination account.
    /// </summary>
    public string? CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_id");
        }
        init { this._rawData.Set("currency_id", value); }
    }

    /// <summary>
    /// ID of the destination account. For a deposit or a transfer, this must always
    /// be an asset account. For withdrawals this must be an expense account.
    /// </summary>
    public string? DestinationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("destination_id");
        }
        init { this._rawData.Set("destination_id", value); }
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
    /// The amount in a foreign currency.
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
    /// Currency code of the foreign currency. Default is NULL. Can be used instead
    /// of the foreign_currency_id, but this or the ID is required when submitting
    /// a foreign amount.
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
    /// Currency ID of the foreign currency. Default is null. Is required when you
    /// submit a foreign amount.
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
    /// Optional. Use either this or the piggy_bank_name
    /// </summary>
    public int? PiggyBankID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("piggy_bank_id");
        }
        init { this._rawData.Set("piggy_bank_id", value); }
    }

    /// <summary>
    /// Optional. Use either this or the piggy_bank_id
    /// </summary>
    public string? PiggyBankName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("piggy_bank_name");
        }
        init { this._rawData.Set("piggy_bank_name", value); }
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
    /// ID of the source account. For a withdrawal or a transfer, this must always
    /// be an asset account. For deposits, this must be a revenue account.
    /// </summary>
    public string? SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_id");
        }
        init { this._rawData.Set("source_id", value); }
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
        _ = this.Date;
        _ = this.Description;
        this.Type.Validate();
        _ = this.BillID;
        _ = this.BillName;
        _ = this.BookDate;
        _ = this.BudgetID;
        _ = this.BudgetName;
        _ = this.CategoryID;
        _ = this.CategoryName;
        _ = this.CurrencyCode;
        _ = this.CurrencyID;
        _ = this.DestinationID;
        _ = this.DestinationName;
        _ = this.DueDate;
        _ = this.ExternalID;
        _ = this.ExternalUrl;
        _ = this.ForeignAmount;
        _ = this.ForeignCurrencyCode;
        _ = this.ForeignCurrencyID;
        _ = this.InterestDate;
        _ = this.InternalReference;
        _ = this.InvoiceDate;
        _ = this.Notes;
        _ = this.Order;
        _ = this.PaymentDate;
        _ = this.PiggyBankID;
        _ = this.PiggyBankName;
        _ = this.ProcessDate;
        _ = this.Reconciled;
        _ = this.SepaBatchID;
        _ = this.SepaCc;
        _ = this.SepaCi;
        _ = this.SepaCountry;
        _ = this.SepaCtID;
        _ = this.SepaCtOp;
        _ = this.SepaDB;
        _ = this.SepaEp;
        _ = this.SourceID;
        _ = this.SourceName;
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
