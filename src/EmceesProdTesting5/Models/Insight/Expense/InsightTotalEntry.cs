using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Insight.Expense;

[JsonConverter(typeof(JsonModelConverter<InsightTotalEntry, InsightTotalEntryFromRaw>))]
public sealed record class InsightTotalEntry : JsonModel
{
    /// <summary>
    /// The currency code of the expenses listed for this expense account.
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
    /// The currency ID of the expenses listed for this expense account.
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
    /// The amount spent between start date and end date, defined as a string, for
    /// this expense account and all asset accounts.
    /// </summary>
    public string? Difference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("difference");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("difference", value);
        }
    }

    /// <summary>
    /// The amount spent between start date and end date, defined as a string, for
    /// this expense account and all asset accounts. This number is a float (double)
    /// and may have rounding errors.
    /// </summary>
    public double? DifferenceFloat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("difference_float");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("difference_float", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrencyCode;
        _ = this.CurrencyID;
        _ = this.Difference;
        _ = this.DifferenceFloat;
    }

    public InsightTotalEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsightTotalEntry(InsightTotalEntry insightTotalEntry)
        : base(insightTotalEntry) { }
#pragma warning restore CS8618

    public InsightTotalEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InsightTotalEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InsightTotalEntryFromRaw.FromRawUnchecked"/>
    public static InsightTotalEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InsightTotalEntryFromRaw : IFromRawJson<InsightTotalEntry>
{
    /// <inheritdoc/>
    public InsightTotalEntry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InsightTotalEntry.FromRawUnchecked(rawData);
}
