using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Chart.Account;

[JsonConverter(typeof(JsonModelConverter<ChartDataSet, ChartDataSetFromRaw>))]
public sealed record class ChartDataSet : JsonModel
{
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

    public DateTimeOffset? Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("date", value);
        }
    }

    public DateTimeOffset? EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("end_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("end_date", value);
        }
    }

    /// <summary>
    /// The actual entries for this data set. They 'key' value is the label for the
    /// data point. The value is the actual (numerical) value.
    /// </summary>
    public JsonElement? Entries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("entries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entries", value);
        }
    }

    /// <summary>
    /// This is the title of the current set. It can refer to an account, a budget
    /// or another object (by name).
    /// </summary>
    public string? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("label");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("label", value);
        }
    }

    /// <summary>
    /// The actual entries for this data set. They 'key' value is the label for the
    /// data point. The value is the actual (numerical) value.
    /// </summary>
    public JsonElement? PcEntries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("pc_entries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pc_entries", value);
        }
    }

    /// <summary>
    /// Period of the chart.
    /// </summary>
    public ApiEnum<string, ChartDataSetPeriod>? Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ChartDataSetPeriod>>("period");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("period", value);
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

    public DateTimeOffset? StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("start_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start_date", value);
        }
    }

    /// <summary>
    /// Indicated the type of chart that is expected to be rendered. You can safely
    /// ignore this if you want.
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
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
    /// Used to indicate the Y axis for this data set. Is usually between 0 and 1
    /// (left and right side of the chart).
    /// </summary>
    public int? YAxisID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("yAxisID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("yAxisID", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencyName;
        _ = this.CurrencySymbol;
        _ = this.Date;
        _ = this.EndDate;
        _ = this.Entries;
        _ = this.Label;
        _ = this.PcEntries;
        this.Period?.Validate();
        _ = this.PrimaryCurrencyCode;
        _ = this.PrimaryCurrencyDecimalPlaces;
        _ = this.PrimaryCurrencyID;
        _ = this.PrimaryCurrencyName;
        _ = this.PrimaryCurrencySymbol;
        _ = this.StartDate;
        _ = this.Type;
        _ = this.YAxisID;
    }

    public ChartDataSet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChartDataSet(ChartDataSet chartDataSet)
        : base(chartDataSet) { }
#pragma warning restore CS8618

    public ChartDataSet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChartDataSet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChartDataSetFromRaw.FromRawUnchecked"/>
    public static ChartDataSet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChartDataSetFromRaw : IFromRawJson<ChartDataSet>
{
    /// <inheritdoc/>
    public ChartDataSet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChartDataSet.FromRawUnchecked(rawData);
}

/// <summary>
/// Period of the chart.
/// </summary>
[JsonConverter(typeof(ChartDataSetPeriodConverter))]
public enum ChartDataSetPeriod
{
    V1D,
    V1W,
    V1M,
    V3M,
    V1Y,
    Custom,
}

sealed class ChartDataSetPeriodConverter : JsonConverter<ChartDataSetPeriod>
{
    public override ChartDataSetPeriod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1D" => ChartDataSetPeriod.V1D,
            "1W" => ChartDataSetPeriod.V1W,
            "1M" => ChartDataSetPeriod.V1M,
            "3M" => ChartDataSetPeriod.V3M,
            "1Y" => ChartDataSetPeriod.V1Y,
            "custom" => ChartDataSetPeriod.Custom,
            _ => (ChartDataSetPeriod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChartDataSetPeriod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChartDataSetPeriod.V1D => "1D",
                ChartDataSetPeriod.V1W => "1W",
                ChartDataSetPeriod.V1M => "1M",
                ChartDataSetPeriod.V3M => "3M",
                ChartDataSetPeriod.V1Y => "1Y",
                ChartDataSetPeriod.Custom => "custom",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
