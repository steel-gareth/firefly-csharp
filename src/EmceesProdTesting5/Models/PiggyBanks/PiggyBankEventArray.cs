using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Models.PiggyBanks;

[JsonConverter(typeof(JsonModelConverter<PiggyBankEventArray, PiggyBankEventArrayFromRaw>))]
public sealed record class PiggyBankEventArray : JsonModel
{
    public required IReadOnlyList<PiggyBankEventArrayData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PiggyBankEventArrayData>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PiggyBankEventArrayData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PageLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PageLink>("links");
        }
        init { this._rawData.Set("links", value); }
    }

    public required Meta Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>("meta");
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Links.Validate();
        this.Meta.Validate();
    }

    public PiggyBankEventArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PiggyBankEventArray(PiggyBankEventArray piggyBankEventArray)
        : base(piggyBankEventArray) { }
#pragma warning restore CS8618

    public PiggyBankEventArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PiggyBankEventArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PiggyBankEventArrayFromRaw.FromRawUnchecked"/>
    public static PiggyBankEventArray FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PiggyBankEventArrayFromRaw : IFromRawJson<PiggyBankEventArray>
{
    /// <inheritdoc/>
    public PiggyBankEventArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PiggyBankEventArray.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PiggyBankEventArrayData, PiggyBankEventArrayDataFromRaw>))]
public sealed record class PiggyBankEventArrayData : JsonModel
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

    public required global::EmceesProdTesting5.Models.PiggyBanks.Attributes Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<global::EmceesProdTesting5.Models.PiggyBanks.Attributes>(
                "attributes"
            );
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

    public PiggyBankEventArrayData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PiggyBankEventArrayData(PiggyBankEventArrayData piggyBankEventArrayData)
        : base(piggyBankEventArrayData) { }
#pragma warning restore CS8618

    public PiggyBankEventArrayData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PiggyBankEventArrayData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PiggyBankEventArrayDataFromRaw.FromRawUnchecked"/>
    public static PiggyBankEventArrayData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PiggyBankEventArrayDataFromRaw : IFromRawJson<PiggyBankEventArrayData>
{
    /// <inheritdoc/>
    public PiggyBankEventArrayData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PiggyBankEventArrayData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::EmceesProdTesting5.Models.PiggyBanks.Attributes,
        global::EmceesProdTesting5.Models.PiggyBanks.AttributesFromRaw
    >)
)]
public sealed record class Attributes : JsonModel
{
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
    /// The transaction group associated with the event.
    /// </summary>
    public string? TransactionGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transaction_group_id");
        }
        init { this._rawData.Set("transaction_group_id", value); }
    }

    /// <summary>
    /// The journal associated with the event.
    /// </summary>
    public string? TransactionJournalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transaction_journal_id");
        }
        init { this._rawData.Set("transaction_journal_id", value); }
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
        _ = this.ObjectHasCurrencySetting;
        _ = this.PcAmount;
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencyName;
        _ = this.PrimaryCurrencySymbol;
        _ = this.TransactionGroupID;
        _ = this.TransactionJournalID;
        _ = this.UpdatedAt;
    }

    public Attributes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attributes(global::EmceesProdTesting5.Models.PiggyBanks.Attributes attributes)
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

    /// <inheritdoc cref="global::EmceesProdTesting5.Models.PiggyBanks.AttributesFromRaw.FromRawUnchecked"/>
    public static global::EmceesProdTesting5.Models.PiggyBanks.Attributes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttributesFromRaw : IFromRawJson<global::EmceesProdTesting5.Models.PiggyBanks.Attributes>
{
    /// <inheritdoc/>
    public global::EmceesProdTesting5.Models.PiggyBanks.Attributes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::EmceesProdTesting5.Models.PiggyBanks.Attributes.FromRawUnchecked(rawData);
}
