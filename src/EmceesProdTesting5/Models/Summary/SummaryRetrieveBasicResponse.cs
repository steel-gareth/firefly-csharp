using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Summary;

[JsonConverter(
    typeof(JsonModelConverter<SummaryRetrieveBasicResponse, SummaryRetrieveBasicResponseFromRaw>)
)]
public sealed record class SummaryRetrieveBasicResponse : JsonModel
{
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
    /// Number of decimals for the associated currency.
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
    /// The currency ID of the associated currency.
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
    /// This is a reference to the type of info shared, not influenced by translations
    /// or user preferences. The EUR value is a reference to the currency code. Possibilities
    /// are: balance-in-ABC, spent-in-ABC, earned-in-ABC, bills-paid-in-ABC, bills-unpaid-in-ABC,
    /// left-to-spend-in-ABC and net-worth-in-ABC.
    /// </summary>
    public string? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    /// <summary>
    /// Reference to a font-awesome icon without the fa- part.
    /// </summary>
    public string? LocalIcon
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("local_icon");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("local_icon", value);
        }
    }

    /// <summary>
    /// The amount as a float.
    /// </summary>
    public double? MonetaryValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("monetary_value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("monetary_value", value);
        }
    }

    /// <summary>
    /// True if there are no available budgets available.
    /// </summary>
    public bool? NoAvailableBudgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("no_available_budgets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("no_available_budgets", value);
        }
    }

    /// <summary>
    /// A short explanation of the amounts origin. Already formatted according to
    /// the locale of the user or translated, if relevant.
    /// </summary>
    public string? SubTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sub_title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sub_title", value);
        }
    }

    /// <summary>
    /// A translated title for the information shared.
    /// </summary>
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

    /// <summary>
    /// The amount formatted according to the users locale
    /// </summary>
    public string? ValueParsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value_parsed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value_parsed", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencySymbol;
        _ = this.Key;
        _ = this.LocalIcon;
        _ = this.MonetaryValue;
        _ = this.NoAvailableBudgets;
        _ = this.SubTitle;
        _ = this.Title;
        _ = this.ValueParsed;
    }

    public SummaryRetrieveBasicResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SummaryRetrieveBasicResponse(SummaryRetrieveBasicResponse summaryRetrieveBasicResponse)
        : base(summaryRetrieveBasicResponse) { }
#pragma warning restore CS8618

    public SummaryRetrieveBasicResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SummaryRetrieveBasicResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SummaryRetrieveBasicResponseFromRaw.FromRawUnchecked"/>
    public static SummaryRetrieveBasicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SummaryRetrieveBasicResponseFromRaw : IFromRawJson<SummaryRetrieveBasicResponse>
{
    /// <inheritdoc/>
    public SummaryRetrieveBasicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SummaryRetrieveBasicResponse.FromRawUnchecked(rawData);
}
