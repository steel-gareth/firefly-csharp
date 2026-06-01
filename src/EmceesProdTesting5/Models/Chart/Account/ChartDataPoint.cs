using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Chart.Account;

[JsonConverter(typeof(JsonModelConverter<ChartDataPoint, ChartDataPointFromRaw>))]
public sealed record class ChartDataPoint : JsonModel
{
    /// <summary>
    /// The key is the label of the value, so for example: '2018-01-01' =&gt; 13
    /// or 'Groceries' =&gt; -123.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
    }

    public ChartDataPoint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChartDataPoint(ChartDataPoint chartDataPoint)
        : base(chartDataPoint) { }
#pragma warning restore CS8618

    public ChartDataPoint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChartDataPoint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChartDataPointFromRaw.FromRawUnchecked"/>
    public static ChartDataPoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChartDataPointFromRaw : IFromRawJson<ChartDataPoint>
{
    /// <inheritdoc/>
    public ChartDataPoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChartDataPoint.FromRawUnchecked(rawData);
}
