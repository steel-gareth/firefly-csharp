using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Insight.Expense;

[JsonConverter(typeof(JsonModelConverter<InsightGroupEntry, InsightGroupEntryFromRaw>))]
public sealed record class InsightGroupEntry : JsonModel
{
    /// <summary>
    /// This ID is a reference to the original object.
    /// </summary>
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
    /// The currency code of the expenses listed for this account.
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
    /// The currency ID of the expenses listed for this account.
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
    /// The amount spent or earned between start date and end date, a number defined
    /// as a string, for this object and all asset accounts.
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
    /// The amount spent or earned between start date and end date, a number as a
    /// float, for this object and all asset accounts. May have rounding errors.
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

    /// <summary>
    /// This is the name of the object.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CurrencyCode;
        _ = this.CurrencyID;
        _ = this.Difference;
        _ = this.DifferenceFloat;
        _ = this.Name;
    }

    public InsightGroupEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsightGroupEntry(InsightGroupEntry insightGroupEntry)
        : base(insightGroupEntry) { }
#pragma warning restore CS8618

    public InsightGroupEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InsightGroupEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InsightGroupEntryFromRaw.FromRawUnchecked"/>
    public static InsightGroupEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InsightGroupEntryFromRaw : IFromRawJson<InsightGroupEntry>
{
    /// <inheritdoc/>
    public InsightGroupEntry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InsightGroupEntry.FromRawUnchecked(rawData);
}
