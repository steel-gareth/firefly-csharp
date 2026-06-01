using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Cron;

[JsonConverter(typeof(JsonModelConverter<CronRunResponse, CronRunResponseFromRaw>))]
public sealed record class CronRunResponse : JsonModel
{
    public CronResultRow? AutoBudgets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CronResultRow>("auto_budgets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("auto_budgets", value);
        }
    }

    public CronResultRow? RecurringTransactions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CronResultRow>("recurring_transactions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recurring_transactions", value);
        }
    }

    public CronResultRow? Telemetry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CronResultRow>("telemetry");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("telemetry", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AutoBudgets?.Validate();
        this.RecurringTransactions?.Validate();
        this.Telemetry?.Validate();
    }

    public CronRunResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CronRunResponse(CronRunResponse cronRunResponse)
        : base(cronRunResponse) { }
#pragma warning restore CS8618

    public CronRunResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CronRunResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CronRunResponseFromRaw.FromRawUnchecked"/>
    public static CronRunResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CronRunResponseFromRaw : IFromRawJson<CronRunResponse>
{
    /// <inheritdoc/>
    public CronRunResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CronRunResponse.FromRawUnchecked(rawData);
}
